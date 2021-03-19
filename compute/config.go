package main

type Config struct {
	Height      int                  `yaml:"height"`
	Width       int                  `yaml:"width"`
	TopLeft     MandelbrotCoordinate `yaml:"topLeft"`
	BottomRight MandelbrotCoordinate `yaml:"bottomRight"`
}
