package main

import (
	"log"

	"github.com/AzureAD/microsoft-authentication-library-for-go/apps/cache"
)

type TokenCache struct {
	data []byte
}

func (t *TokenCache) Replace(cache cache.Unmarshaler, key string) {
	// jsonFile, err := os.Open(t.file)
	// if err != nil {
	// 	log.Println(err)
	// }
	// defer jsonFile.Close()
	// data, err := ioutil.ReadAll(jsonFile)
	// if err != nil {
	// 	log.Println(err)
	// }
	err := cache.Unmarshal(t.data)
	if err != nil {
		log.Println(err)
	}
}

func (t *TokenCache) Export(cache cache.Marshaler, key string) {
	data, err := cache.Marshal()
	if err != nil {
		log.Println(err)
	}
	t.data = data
	// err = ioutil.WriteFile(t.file, data, 0600)
	// if err != nil {
	// 	log.Println(err)
	// }
}
