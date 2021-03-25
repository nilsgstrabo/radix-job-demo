package main

import (
	"fmt"
	"net/http"
	"os"

	"github.com/sirupsen/logrus"
)

func startServer(responseBody []byte) *http.Server {
	port := os.Getenv("PORT")

	srv := &http.Server{Addr: fmt.Sprintf(":%s", port)}
	http.Handle("/", http.HandlerFunc(serve(responseBody)))
	go func() {
		if err := srv.ListenAndServe(); err != nil {
			switch err {
			case http.ErrServerClosed:
				logrus.Info(err)
			default:
				logrus.Fatal(err)
			}

		}
	}()

	return srv
}

func serve(body []byte) http.HandlerFunc {
	return func(rw http.ResponseWriter, r *http.Request) {
		logrus.Infof("recevied request %v", r.RequestURI)
		rw.Write(body)
	}

}
