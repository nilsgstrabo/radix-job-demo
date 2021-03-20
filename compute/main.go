package main

import (
	"fmt"
	"image"
	"image/color"
	"image/png"
	"io/ioutil"
	"os"
	"path/filepath"

	"github.com/sirupsen/logrus"
	"gopkg.in/yaml.v2"
)

var colors []color.RGBA = []color.RGBA{
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

func getcolor(i uint8) color.RGBA {
	if i < 255 && i > 0 {
		return colors[i%16]
	}
	return color.RGBA{0, 0, 0, 255}
}

func main() {

	cfgFile := os.Getenv("COMPUTE_CONFIG")
	outPath := os.Getenv("COMPUTE_OUT_PATH")
	cfgBytes, err := ioutil.ReadFile(cfgFile)
	if err != nil {
		logrus.Panic(err)
	}

	var config Config

	if err := yaml.Unmarshal(cfgBytes, &config); err != nil {
		logrus.Panic(err)
	}

	logrus.Infof("Config file: %s\n", cfgFile)
	logrus.Infof("Output directory: %s\n", outPath)
	logrus.Infof("Config: %v", config)

	mandelbrot := Mandelbrot{
		Height:      config.Height,
		Width:       config.Width,
		TopLeft:     config.Top,
		BottomRight: config.Bottom,
	}
	m_bitmap := mandelbrot.Bitmap()
	img := image.NewRGBA(image.Rect(0, 0, mandelbrot.Width, mandelbrot.Height))

	for x := 0; x < mandelbrot.Width; x++ {
		for y := 0; y < mandelbrot.Height; y++ {

			img.Set(x, y, getcolor(m_bitmap[y][x]))
		}
	}
	outFile := filepath.Join(outPath, fmt.Sprintf("%v.png", config.ImageId))
	logrus.Infof("Writing new image to %v", outFile)
	f, err := os.Create(outFile)
	if err != nil {
		logrus.Panic(err)
	}

	png.Encode(f, img)

}
