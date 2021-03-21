package main

import (
	"image/color"
)

type Coloring interface {
	Color(iteration uint8) color.RGBA
}

type colorer struct {
	colors []color.RGBA
}

func (c *colorer) Color(iteration uint8) color.RGBA {
	if iteration < 255 && iteration > 0 {
		return c.colors[iteration%16]
	}
	return color.RGBA{0, 0, 0, 255}
}

func NewColorer(colors []color.RGBA) Coloring {
	c := colorer{colors: colors}
	return &c
}

// func smoothenColors(colors []color.RGBA) []color.RGBA {
// 	totalColors := 255
// 	frames := len(colors) - 1
// 	colorsPerFrame := float64(totalColors-1) / float64(frames)
// 	colorInfo := make(map[int]uint8, len(colors))

// 	currentIndex := 0.0
// 	for i := 0; i < len(colors); i++ {
// 		colorInfo[i] = uint8(currentIndex + 0.5)
// 		currentIndex += colorsPerFrame
// 	}

// 	fmt.Println(colorInfo)

// 	newColors := make([]color.RGBA, totalColors)
// 	for i := 0; i < frames; i++ {
// 		startColor := colors[i]
// 		endColor := colors[i+1]
// 		startIndex := colorInfo[i]
// 		endIndex := colorInfo[i+1]
// 		redStep := float64(int(endColor.R)-int(startColor.R)) / float64(endIndex-startIndex+1)
// 		greenStep := float64(int(endColor.G)-int(startColor.G)) / float64(endIndex-startIndex+1)
// 		blueStep := float64(int(endColor.B)-int(startColor.B)) / float64(endIndex-startIndex+1)

// 		newColors[startIndex] = startColor
// 		// fmt.Printf("R: %v  -  %v\n", startColor.R, endColor.R)
// 		// fmt.Printf("R diff: %v\n", float64(endColor.R-startColor.R))
// 		// fmt.Printf("idx: %v  -  %v\n", startIndex, endIndex)
// 		// fmt.Printf("step: %v\n", redStep)
// 		// fmt.Printf("R: %v\n", startColor.R)
// 		fmt.Printf("Start color: %v\n", startColor)
// 		for j := startIndex + 1; j <= endIndex; j++ {
// 			//redOffset := float64(j-startIndex) * redStep
// 			newRed := startColor.R + uint8(float64(j-startIndex)*redStep)
// 			newGreen := startColor.G + uint8(float64(j-startIndex)*greenStep)
// 			newBlue := startColor.B + uint8(float64(j-startIndex)*blueStep)
// 			//fmt.Printf("   New R: %v\n", newRed)
// 			newColor := color.RGBA{R: newRed, G: newGreen, B: newBlue, A: 255}
// 			fmt.Printf("  New color: %v\n", newColor)
// 			newColors[j] = newColor
// 		}

// 	}
// 	fmt.Println(newColors)
// 	return newColors
// 	//return colors
// }
