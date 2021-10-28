package main

import (
	"bytes"
	"encoding/base64"
	"encoding/json"
	"fmt"
	"image"
	"image/color"
	"image/png"
	"io/ioutil"
	"net/http"
	"net/url"
	"os"
	"path/filepath"
	"strings"

	// "time"

	"github.com/sirupsen/logrus"
	"gopkg.in/yaml.v2"
)

type ImagePostData struct {
	Data string `json:"data"`
}

type CallbackRequest struct {
	Top    MandelbrotCoordinate `json:"top"`
	Bottom MandelbrotCoordinate `json:"bottom"`
}

var basecolors []color.RGBA = []color.RGBA{
	{66, 30, 15, 255},
	{25, 7, 26, 255},
	{9, 1, 47, 255},
	{4, 4, 73, 255},
	{0, 7, 100, 255},
	{12, 44, 138, 255},
	{24, 82, 177, 255},
	{57, 125, 209, 255},
	{134, 181, 229, 255},
	{211, 236, 248, 255},
	{241, 233, 191, 255},
	{248, 201, 95, 255},
	{255, 170, 0, 255},
	{204, 128, 0, 255},
	{153, 87, 0, 255},
	{106, 52, 3, 255},
}

func main() {

	cfgFile := os.Getenv("COMPUTE_CONFIG")
	outPath := os.Getenv("COMPUTE_OUT_PATH")
	callbackCompleteUrl := os.Getenv("CALLBACK_ON_COMPLETE_URL")

	logrus.Infof("Config file: %s\n", cfgFile)
	logrus.Infof("Output directory: %s\n", outPath)
	logrus.Infof("CALLBACK_ON_COMPLETE_URL: %s\n", callbackCompleteUrl)

	cfgBytes, err := ioutil.ReadFile(cfgFile)
	if err != nil {
		logrus.Panicf("error reading config file: %v", err)
	}

	var config Config

	if err := yaml.Unmarshal(cfgBytes, &config); err != nil {
		logrus.Panicf("error unmarshalling config file: %v", err)
	}

	logrus.Infof("Config: %v", config)

	mandelbrot := Mandelbrot{
		Height:      config.Height,
		Width:       config.Width,
		TopLeft:     config.Top,
		BottomRight: config.Bottom,
	}
	m_bitmap := mandelbrot.Bitmap()
	img := image.NewRGBA(image.Rect(0, 0, mandelbrot.Width, mandelbrot.Height))
	colorer := NewColorer(basecolors)

	for x := 0; x < mandelbrot.Width; x++ {
		for y := 0; y < mandelbrot.Height; y++ {

			img.Set(x, y, colorer.Color(m_bitmap[y][x]))
		}
	}

	if strings.TrimSpace(outPath) != "" {
		outFile := filepath.Join(outPath, fmt.Sprintf("%v.png", config.ImageId))
		logrus.Infof("Writing new image to %v", outFile)
		f, err := os.Create(outFile)
		if err != nil {
			logrus.Panicf("error writing image to out path: %v", err)
		}

		if err = png.Encode(f, img); err != nil {
			logrus.Panicf("error encoding png: %v", err)
		}
		f.Close()
	}

	if strings.TrimSpace(callbackCompleteUrl) != "" {
		postAdr, _ := url.Parse(callbackCompleteUrl)
		postAdr.Path = fmt.Sprintf("%s/%v/data", "api/image", config.ImageId)
		postAdrStr := postAdr.String()

		imgBuf := new(bytes.Buffer)
		err = png.Encode(imgBuf, img)
		if err != nil {
			logrus.Panicf("unable to encode png: %v", err)
		}
		imgBytes := imgBuf.Bytes()
		sEnc := base64.StdEncoding.EncodeToString(imgBytes)
		logrus.Infof("Posting image (%v bytes) to %s", len(sEnc), postAdrStr)
		imgData := ImagePostData{Data: sEnc}
		imgPostBytes, err := json.Marshal(imgData)
		if err != nil {
			logrus.Panicf("error marshalling image post data: %v", err)
		}
		resp, err := http.Post(postAdrStr, "application/json", bytes.NewBuffer(imgPostBytes))
		if err != nil {
			logrus.Panicf("error posting image: %v", err)
		}
		logrus.Infof("Response on POST image: code %v", resp.Status)

		adr, err := url.Parse(callbackCompleteUrl)
		if err != nil {
			logrus.Panicf("unable to parse CALLBACK_ON_COMPLETE_URL: %v", err)
		}
		adr.Path = fmt.Sprintf("%s/%v", "api/image", config.ImageId)
		adrStr := adr.String()
		callbackBody, err := json.Marshal(CallbackRequest{Top: config.Top, Bottom: config.Bottom})
		if err != nil {
			logrus.Panicf("error unmarshalling callbackBody: %v", err)
		}
		resp, err = http.Post(adrStr, "application/json", bytes.NewBuffer(callbackBody))
		if err != nil {
			logrus.Panicf("error posting result: %v", err)
		}
		logrus.Infof("Response on POST to complete URL %s: code %v", adrStr, resp.Status)

		defer resp.Body.Close()
	}
}
