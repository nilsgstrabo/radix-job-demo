package main

// MandelbrotCoordinate defines a point in the mandelbrot coordinate set
// X scale (-2.5, 1)
// Y scale (-1, 1)
type MandelbrotCoordinate struct {
	// X scale (-2.5, 1)
	X float64 `yaml:"x"`
	// Y scale (-1, 1)
	Y float64 `yaml:"y"`
}

type Mandelbrot struct {
	Height      int
	Width       int
	TopLeft     MandelbrotCoordinate
	BottomRight MandelbrotCoordinate
}

func (m *Mandelbrot) Bitmap() [][]uint8 {
	var bitmap [][]uint8 = make([][]uint8, m.Height, m.Height)

	for y := 0; y < m.Height; y++ {
		bitmap[y] = make([]uint8, m.Width, m.Width)

		for x := 0; x < m.Width; x++ {
			bitmap[y][x] = m.pixel(x, y)
		}
	}

	return bitmap
}

func (m *Mandelbrot) pixel(x, y int) uint8 {
	// Mandelbrot X scale (-2.5, 1)
	// Mandelbrot Y scale (-1, 1)
	mcoord := m.scale(x, y)

	vx := 0.0
	vy := 0.0
	maxIteration := 255
	i := 0

	for vx*vx+vy*vy <= 2*2 && i < maxIteration {
		xtemp := vx*vx - vy*vy + mcoord.X
		vy = 2*vx*vy + mcoord.Y
		vx = xtemp
		i++
	}

	color := uint8(i)
	return color
}

func (m *Mandelbrot) scale(x, y int) MandelbrotCoordinate {
	mwidthstep := (m.BottomRight.X - m.TopLeft.X) / float64(m.Width)
	mheightstep := (m.BottomRight.Y - m.TopLeft.Y) / float64(m.Height)

	return MandelbrotCoordinate{
		X: m.TopLeft.X + (float64(x) * mwidthstep),
		Y: m.TopLeft.Y + (float64(y) * mheightstep),
	}

}
