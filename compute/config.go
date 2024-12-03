package main

type Config struct {
	ImageId      int                  `yaml:"imageId"`
	Height       int                  `yaml:"height"`
	Width        int                  `yaml:"width"`
	Top          MandelbrotCoordinate `yaml:"top"`
	Bottom       MandelbrotCoordinate `yaml:"bottom"`
	Sleep        int                  `yaml:"sleep"`
	Fail         bool                 `yaml:"fail"`
	FailExitCode int                  `yaml:"failExitCode"`
	StringVal    string               `yaml:"stringVal"`
}
