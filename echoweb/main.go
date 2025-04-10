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
			w.Write([]byte(fmt.Sprintf("Returned code %v", code)))
			return
		}
	}
	w.WriteHeader(200)
	w.Write([]byte("all good\n"))

	responseKb := 1
	if v := r.URL.Query().Get("size"); len(v) > 0 {
		if n, err := strconv.Atoi(v); err == nil {
			responseKb = n
		}
	}
	sleep := 0
	if v := r.URL.Query().Get("sleep"); len(v) > 0 {
		if n, err := strconv.Atoi(v); err == nil {
			sleep = n
		}
	}
	fmt.Printf("writing %v KB and sleeping %v seconds between each KB", responseKb, sleep)
	for range responseKb {
		w.Write([]byte(strings.Repeat(responsePart, 16)))
		w.(http.Flusher).Flush()
		time.Sleep(time.Duration(sleep) * time.Second)
	}
}

func init() {
	var sb strings.Builder

	for i := range 64 {
		sb.WriteByte(byte(i + 65))
	}
	responsePart = sb.String()
}
