package main

import (
	"context"

	"github.com/AzureAD/microsoft-authentication-library-for-go/apps/cache"
)

type TokenCache struct {
	data []byte
}

func (t *TokenCache) Replace(ctx context.Context, cache cache.Unmarshaler, hints cache.ReplaceHints) error {
	// jsonFile, err := os.Open(t.file)
	// if err != nil {
	// 	log.Println(err)
	// }
	// defer jsonFile.Close()
	// data, err := ioutil.ReadAll(jsonFile)
	// if err != nil {
	// 	log.Println(err)
	// }
	return cache.Unmarshal(t.data)
}

func (t *TokenCache) Export(ctx context.Context, cache cache.Marshaler, hints cache.ExportHints) error {
	data, err := cache.Marshal()
	if err != nil {
		return err
	}
	t.data = data
	return nil
}
