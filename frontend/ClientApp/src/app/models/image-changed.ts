import { MandelbrotCoord } from "./mandelbrot-coord";

export interface ImageChanged {
    imageId: number;
    top: MandelbrotCoord;
    bottom: MandelbrotCoord;
}