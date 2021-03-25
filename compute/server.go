package main

import (
	"fmt"
	"net/http"
	"os"

	"github.com/prometheus/common/log"
)

func startServer(responseBody []byte) *http.Server {
	port := os.Getenv("PORT")

	srv := &http.Server{Addr: fmt.Sprintf(":%s", port)}
	http.Handle("/", http.HandlerFunc(serve(responseBody)))
	go func() {
		if err := srv.ListenAndServe(); err != nil {
			switch err {
			case http.ErrServerClosed:
				log.Info(err)
			default:
				log.Fatal(err)
			}

		}
	}()

	return srv
}

func serve(body []byte) http.HandlerFunc {
	return func(rw http.ResponseWriter, r *http.Request) {
		log.Infof("recevied request %v", r.RequestURI)
		rw.Write(body)
	}

}
