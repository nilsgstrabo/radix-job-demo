import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { Subscription, timer } from 'rxjs';
import { switchMap, exhaustMap, tap } from 'rxjs/operators';
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
export class HomeComponent implements OnInit, OnDestroy {
  private imageWidth = 1050;
  private imageHeight = 600;
  private boxWidth = 175;
  private boxHeight = 100;
  private jobListSubscription: Subscription;
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

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.jobListSubscription = timer(1000, 2000).pipe(
      exhaustMap(() => this.getJobList())
    ).subscribe(v => this.setJobList(v), err => console.error(err));
  }

  ngOnDestroy() {
    if (this.jobListSubscription) {
      this.jobListSubscription.unsubscribe();
    }
  }

  private getNextImageId() {
    return this.nextImageId++;
  }

  resetImage() {
    const mwin: MandelbrotWindow = {
      top: {
        x: -2.5,
        y: -1
      },
      bottom: {
        x: 1,
        y: 1
      }
    };
    this.sendImageRequest(mwin).then(r => this.addJobToList(r)).catch(e => console.error(e));

  }

  private getJobList() {
    return this.http.get<any[]>('/api/compute/jobs', getJsonOptions);
  }

  private setJobList(jobs: any[]) {
    this.jobs = jobs.sort((a, b) => a.started > b.started ? 1 : -1);
  }

  private addJobToList(job: any) {
    console.log('new job', job)
    this.jobs.unshift(job);
  }

  async onAreaSelected(event: MandelbrotCoord) {

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
      this.addJobToList(response);
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
