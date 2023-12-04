package main

import (
	"fmt"
	"net/http"
	"strconv"
)

func main() {
	err := http.ListenAndServe(":8000", http.HandlerFunc(handle))
	if err != nil {
		panic(err)
	}
}

func handle(w http.ResponseWriter, r *http.Request) {
	r.ParseForm()
	if codeStr := r.Form.Get("code"); len(codeStr) > 0 {
		if code, err := strconv.Atoi(codeStr); err == nil {
			w.WriteHeader(code)
			w.Write([]byte(fmt.Sprintf("returned code %v", code)))
			return
		}
	}
	w.WriteHeader(200)
	w.Write([]byte("all good"))
}
