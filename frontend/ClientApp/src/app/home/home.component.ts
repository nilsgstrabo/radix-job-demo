import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { of, Subscription, timer } from 'rxjs';
import { switchMap, exhaustMap, tap, catchError, retryWhen, retry, map, delayWhen, delay, take } from 'rxjs/operators';
import { ImageChanged } from '../models/image-changed';
import { MandelbrotCoord } from '../models/mandelbrot-coord';
import { NotificationHubService } from '../services/notification-hub.service';
const getJsonOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

enum JobStatus {
  Waiting = 1,
  Running = 2,
  Succeeded = 3,
  Stopping = 4,
  Stopped = 5,
  Failed = 6
}

interface MandelbrotWindow {
  top: MandelbrotCoord
  bottom: MandelbrotCoord;
}

interface ComputeRequest {
  imageId: number;
  mandelbrotWindow: MandelbrotWindow;
  memory: number,
  cpu: number,
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
  private imageChangedSubscription: Subscription;
  private timeChangedSubscription: Subscription;
  memory=0;
  cpu=0;
  jobs: any[] = [];
  imageReceivedMessage = '';
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

  constructor(private http: HttpClient, private hub: NotificationHubService) { }

  ngOnInit() {
    this.jobListSubscription = timer(1000, 5*60*1000).pipe(
      exhaustMap(() => this.getJobList().pipe(catchError(e => of([]))))
    ).subscribe(v => this.setJobList(v), err => console.error(err));

    this.imageChangedSubscription = this.hub.imageChanged.subscribe(v => this.imageChanged(v), e => console.error(e));
    this.timeChangedSubscription = this.hub.timeChanged.subscribe(v => this.timeChanged(v), e => console.error(e));
  }

  ngOnDestroy() {
    if (this.jobListSubscription) {
      this.jobListSubscription.unsubscribe();
    }
    if (this.imageChangedSubscription) {
      this.imageChangedSubscription.unsubscribe();
    }
  }

  public getStatus(status: JobStatus) {
    return JobStatus[status];
  }

  private timeChanged(time: any) {
    console.log(time);
  }

  private imageChanged(img: ImageChanged) {
    this.imageReceivedMessage = `Image with id ${img.imageId} received. Wait for blob storage sync`;
    this.checkImageExist(img.imageId).pipe(take(1)).toPromise().then(() => {
      this.imageReceivedMessage = `Image with id ${img.imageId} successfully synced`;
      this.imageId = img.imageId;
      this.windowCoord = img;
    });
  }

  private checkImageExist(imageId: number) {
    return this.http.get(`/api/image/${imageId}/_exists`).pipe(
      retryWhen(e => e.pipe(
        tap(() => {
          this.imageReceivedMessage = `Image with id ${imageId} not synced yet`;
        }),
        delay(1000),
        take(1000 * 300)
      ))
    )
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
    this.jobs = jobs.sort((a, b) => a.started > b.started ? -1 : 1);
  }

  private addJobToList(job: any) {
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
      mandelbrotWindow: mandelbrot,
      memory: Number(this.memory),
      cpu: Number(this.cpu)
    };

    const response = await this.http.post('/api/compute/jobs', request, getJsonOptions).toPromise();
    return response
  }

  async kill() {
    await this.http.post('/api/compute/kill', null, getJsonOptions).toPromise();
 }
}
