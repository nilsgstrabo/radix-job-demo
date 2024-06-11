package main

import (
	"fmt"
	"net/http"
	"strconv"
)

func main() {
	addr := ":8000"
	fmt.Printf("server listening on address %s", addr)

	err := http.ListenAndServe(addr, http.HandlerFunc(handle))
	if err != nil {
		panic(err)
	}
}

func handle(w http.ResponseWriter, r *http.Request) {
	fmt.Printf("%s - %v", r.RemoteAddr, r.URL)
	r.ParseForm()
	if codeStr := r.Form.Get("code"); len(codeStr) > 0 {
		if code, err := strconv.Atoi(codeStr); err == nil {
			w.WriteHeader(code)
			w.Write([]byte(fmt.Sprintf("Returned code %v", code)))
			return
		}
	}
	w.WriteHeader(200)
	w.Write([]byte("all good"))
}
