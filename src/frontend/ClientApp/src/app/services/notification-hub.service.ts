import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { ImageChanged } from '../models/image-changed';
import { MandelbrotCoord } from '../models/mandelbrot-coord';



@Injectable()
export class NotificationHubService {

    private connection?: signalR.HubConnection;
    private imageChangedSubject = new Subject<ImageChanged>();
    imageChanged = this.imageChangedSubject.asObservable();

    private timeChangedSubject = new Subject<ImageChanged>();
    timeChanged = this.timeChangedSubject.asObservable();

    constructor() {
        this.createConnection();
        this.registerServerEvents();
        this.startConnection();
    }

    private createConnection() {
        this.connection = new signalR.HubConnectionBuilder().withUrl('/notificationhub').build();
        this.connection.serverTimeoutInMilliseconds=30*1000;
    }

    private startConnection() {
        this.connection?.start().then(() => console.log(new Date().toLocaleString(), 'connection started')).catch(e => console.log(e));
    }

    private registerServerEvents(): void {
        this.connection?.onclose((e)=> {
            console.log(new Date().toLocaleString() ,'connection closed');
            this.startConnection();
        })
        this.connection?.on('imageChanged', (img) => this.imageChangedSubject.next(img));
        this.connection?.on('timeChanged', (img) => this.timeChangedSubject.next(img));
    }



}