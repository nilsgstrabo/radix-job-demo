package main

import (
	"fmt"
	"image"
	"image/color"
	"image/png"
	"io/ioutil"
	"os"
	"path/filepath"

	"gopkg.in/yaml.v2"
)

func main() {

	cfgFile := os.Getenv("COMPUTE_CONFIG")
	outPath := os.Getenv("COMPUTE_OUT_PATH")
	cfgBytes, err := ioutil.ReadFile(cfgFile)
	if err != nil {
		panic(err)
	}

	var config Config

	yaml.Unmarshal(cfgBytes, &config)

	fmt.Printf("Config file: %s\n", cfgFile)
	fmt.Printf("Output directory: %s\n", outPath)
	fmt.Printf("Config: %v", config)

	mandelbrot := Mandelbrot{
		Height:      config.Height,
		Width:       config.Width,
		TopLeft:     config.TopLeft,
		BottomRight: config.BottomRight,
	}
	m_bitmap := mandelbrot.Bitmap()
	img := image.NewRGBA(image.Rect(0, 0, mandelbrot.Width, mandelbrot.Height))

	for x := 0; x < mandelbrot.Width; x++ {
		for y := 0; y < mandelbrot.Height; y++ {
			img.Set(x, y, color.RGBA{A: 255, B: m_bitmap[y][x]})
		}
	}
	outFile := filepath.Join(outPath, "mandelbrot.png")
	f, err := os.Create(outFile)
	if err != nil {
		panic(err)
	}

	png.Encode(f, img)

}
