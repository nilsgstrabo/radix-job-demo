package main

import (
	"context"
	"database/sql"
	"fmt"
	"os"
	"time"

	"github.com/AzureAD/microsoft-authentication-library-for-go/apps/confidential"
	mssql "github.com/denisenkom/go-mssqldb"
	"github.com/denisenkom/go-mssqldb/msdsn"
)

func doSqlQuery() {
	scopes := []string{"https://database.windows.net/.default"}

	cred := confidential.NewCredFromAssertionCallback(func(ctx context.Context, aro confidential.AssertionRequestOptions) (string, error) {
		token, err := os.ReadFile(os.Getenv("AZURE_FEDERATED_TOKEN_FILE"))
		return string(token), err
	})

	confidentialClientApp, err := confidential.New(
		os.Getenv("AZURE_CLIENT_ID"),
		cred,
		confidential.WithAuthority(fmt.Sprintf("%s%s/oauth2/token", os.Getenv("AZURE_AUTHORITY_HOST"), os.Getenv("AZURE_TENANT_ID"))),
		confidential.WithAccessor(&TokenCache{}),
	)
	if err != nil {
		fmt.Println(err)
		return
	}
	getToken := func(ctx context.Context) (string, error) {
		var authResult confidential.AuthResult
		authResult, err := confidentialClientApp.AcquireTokenSilent(ctx, scopes)
		if err != nil {
			fmt.Println("requesting new token")
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
		msdsn.Config{Host: os.Getenv("SERVER_NAME"), Database: os.Getenv("DATABASE_NAME")},
		getToken)

	if err != nil {
		fmt.Println(err)
		return
	}
	db := sql.OpenDB(connector)
	defer db.Close()

	for {
		func() {
			conn, err := db.Conn(context.Background())
			if err != nil {
				fmt.Println(err)
				return
			}
			defer conn.Close()
			rows, err := db.QueryContext(context.Background(), "select count(1) as cnt from dbo.Vulnerability")
			if err != nil {
				fmt.Println(err)
				return
			}
			defer rows.Close()
			var rowcount int64
			for rows.Next() {
				rows.Scan(&rowcount)
				fmt.Printf("%v: there are %d rows in dbo.Vulnerability\n", time.Now(), rowcount)
			}
		}()
	}
}
