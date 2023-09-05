package main

import (
	"context"
	"database/sql"
	"fmt"
	"net/url"
	"os"
	"time"

	"github.com/Azure/azure-sdk-for-go/sdk/azcore/policy"
	"github.com/Azure/azure-sdk-for-go/sdk/azidentity"
	"github.com/AzureAD/microsoft-authentication-library-for-go/apps/confidential"
	mssql "github.com/denisenkom/go-mssqldb"
	"github.com/denisenkom/go-mssqldb/msdsn"
	"github.com/sirupsen/logrus"
)

func doSqlQuery() {
	scopes := []string{"https://database.windows.net/.default"}

	cred := confidential.NewCredFromAssertionCallback(func(ctx context.Context, aro confidential.AssertionRequestOptions) (string, error) {
		token, err := os.ReadFile(os.Getenv("AZURE_FEDERATED_TOKEN_FILE"))
		return string(token), err
	})
	authority, err := url.JoinPath(os.Getenv("AZURE_AUTHORITY_HOST"), os.Getenv("AZURE_TENANT_ID"), "oauth", "token")
	if err != nil {
		logrus.Errorf("error composing authority: %v", err)
		return
	}
	// authority := fmt.Sprintf("%s%s/oauth2/token", os.Getenv("AZURE_AUTHORITY_HOST"), os.Getenv("AZURE_TENANT_ID"))
	logrus.Infof("using authority %s\n", authority)
	confidentialClientApp, err := confidential.New(
		os.Getenv("AZURE_CLIENT_ID"),
		cred,
		confidential.WithAuthority(authority),
		confidential.WithAccessor(&TokenCache{}),
	)
	if err != nil {
		logrus.Errorf("error creating confidential client: %v", err)
		return
	}
	creds, err := azidentity.NewManagedIdentityCredential("", nil)
	if err != nil {
		logrus.Errorf("NewManagedIdentityCredential: %v", err)
		return
	}
	token, err := creds.GetToken(context.Background(), policy.TokenRequestOptions{Scopes: scopes})
	if err != nil {
		logrus.Errorf("GetToken: %v", err)
		return
	}
	fmt.Printf("Got token with expiry %v\n", token.ExpiresOn)

	getToken := func(ctx context.Context) (string, error) {
		var authResult confidential.AuthResult
		authResult, err := confidentialClientApp.AcquireTokenSilent(ctx, scopes)
		if err != nil {
			logrus.Infof("requesting new token for sql credentials")
			authResult, err = confidentialClientApp.AcquireTokenByCredential(ctx, scopes)
			if err != nil {
				fmt.Println(err)
				return "", err
			}
		}
		// fmt.Println(authResult.AccessToken)
		return authResult.AccessToken, nil
	}
	connector, err := mssql.NewSecurityTokenConnector(
		msdsn.Config{Host: os.Getenv("SQL_SERVER_NAME"), Database: os.Getenv("SQL_DATABASE_NAME")},
		getToken)

	if err != nil {
		logrus.Errorf("error creating sql connector: %v", err)
		return
	}
	db := sql.OpenDB(connector)
	defer db.Close()

	func() {
		conn, err := db.Conn(context.Background())
		if err != nil {
			logrus.Errorf("error connecting to sql database: %v", err)
			return
		}
		defer conn.Close()
		rows, err := db.QueryContext(context.Background(), "select count(1) as cnt from dbo.Products")
		if err != nil {
			logrus.Errorf("error executing query: %v", err)
			return
		}
		defer rows.Close()
		var rowcount int64
		for rows.Next() {
			rows.Scan(&rowcount)
			logrus.Infof("%v: there are %d rows in dbo.Products\n", time.Now(), rowcount)
		}
	}()

}
