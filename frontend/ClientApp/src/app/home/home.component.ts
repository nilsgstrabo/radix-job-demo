import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, HostListener } from '@angular/core';

const getJsonOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

interface MandelbrotCoord {
  x: number;
  y: number;
}

interface MandelbrotWindow {
  top: MandelbrotCoord
  bottom: MandelbrotCoord;
}

interface ComputeRequest {
  imageId: number;
  mandelbrotWindow: MandelbrotWindow;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private imageWidth = 1050;
  private imageHeight = 600;
  private boxWidth = 175;
  private boxHeight = 100;
  jobs: any[] = [];
  imageId = 1;
  nextImageId = 2;
  windowCoord: MandelbrotWindow = {
    top: {
      x: -2.5,
      y: -1
    },
    bottom: {
      x: 1,
      y: 1
    }
  }
  constructor(private http: HttpClient) {

  }

  private getNextImageId() {
    return this.nextImageId++;
  }

  resetImage() {

    this.sendImageRequest({
      top: {
        x: -2.5,
        y: -1
      },
      bottom:{
        x: 1,
        y: 1
      }
    }).then(r=>console.log(r)).catch(e=>console.error(e));

  }

  async onAreaSelected(event: MandelbrotCoord) {
    console.log(event);
    const top: MandelbrotCoord = {
      x: ((this.windowCoord.bottom.x - this.windowCoord.top.x) / this.imageWidth * event.x) + this.windowCoord.top.x,
      y: ((this.windowCoord.bottom.y - this.windowCoord.top.y) / this.imageHeight * event.y) + this.windowCoord.top.y,
    };
    const bottom: MandelbrotCoord = {
      x: ((this.windowCoord.bottom.x - this.windowCoord.top.x) / this.imageWidth * (event.x + this.boxWidth)) + this.windowCoord.top.x,
      y: ((this.windowCoord.bottom.y - this.windowCoord.top.y) / this.imageHeight * (event.y + this.boxHeight)) + this.windowCoord.top.y,
    };

    try {
      const response = await this.sendImageRequest({ top: top, bottom: bottom });
    } catch (error) {
      console.error(error);
    }
  }

  async sendImageRequest(mandelbrot: MandelbrotWindow) {
    const request: ComputeRequest = {
      imageId: this.getNextImageId(),
      mandelbrotWindow: mandelbrot
    };

    console.log(request);

    const response = await this.http.post('/api/compute/jobs', request, getJsonOptions).toPromise();
    return response
  }
}
