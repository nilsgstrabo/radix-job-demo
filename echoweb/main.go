package main

import (
	"fmt"
	"net/http"
	"strconv"
	"strings"
	"time"
)

func main() {
	addr := ":8000"
	fmt.Printf("server listening on address %s", addr)

	err := http.ListenAndServe(addr, http.HandlerFunc(handle))
	if err != nil {
		panic(err)
	}
}

var (
	responsePart string
)

func handle(w http.ResponseWriter, r *http.Request) {
	fmt.Printf("%s - %v\n", r.RemoteAddr, r.URL)
	r.ParseForm()
	if codeStr := r.URL.Query().Get("code"); len(codeStr) > 0 {
		if code, err := strconv.Atoi(codeStr); err == nil {
			w.WriteHeader(code)
			fmt.Fprintf(w, "Returned code %v", code)
			return
		}
	}
	initialSleep := 0 * time.Second
	if v := r.URL.Query().Get("initialsleep"); len(v) > 0 {
		if n, err := strconv.Atoi(v); err == nil {
			initialSleep = time.Duration(n) * time.Second
		}
	}
	fmt.Printf("sleeping for %v before response\n", initialSleep)
	time.Sleep(initialSleep)
	w.WriteHeader(200)
	w.Write([]byte("all good\n"))

	responseKb := 1
	if v := r.URL.Query().Get("size"); len(v) > 0 {
		if n, err := strconv.Atoi(v); err == nil {
			responseKb = n
		}
	}
	sleep := 0 * time.Second
	if v := r.URL.Query().Get("sleep"); len(v) > 0 {
		if n, err := strconv.Atoi(v); err == nil {
			sleep = time.Duration(n) * time.Second
		}
	}
	fmt.Printf("writing %v KB and sleeping %v between each KB\n", responseKb, sleep)
	for range responseKb {
		_, err := w.Write([]byte(strings.Repeat(responsePart, 16)))
		if err != nil {
			fmt.Printf("error: %v\n", err)
		}
		w.(http.Flusher).Flush()
		fmt.Printf("#%v: flushing and waiting for %v\n", responseKb, sleep)
		time.Sleep(sleep)
	}
	fmt.Print("Done")
	w.Write([]byte("\nI'm all done\n"))
}

func init() {
	var sb strings.Builder

	for i := range 64 {
		sb.WriteByte(byte(i + 65))
	}
	responsePart = sb.String()
}
