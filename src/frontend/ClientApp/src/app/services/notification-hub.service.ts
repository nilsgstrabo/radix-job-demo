import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
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
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl('/notificationhub')
            .withAutomaticReconnect()
            .build();

        this.connection.serverTimeoutInMilliseconds=1000*1000;
        this.connection.keepAliveIntervalInMilliseconds=1000*1000;
    }

    private startConnection() {
        this.connection?.start().then(() => console.log(new Date().toLocaleString(), 'connection started')).catch(e => console.log(e));
    }

    private registerServerEvents(): void {
        this.connection?.onclose((e)=> {
            console.log(new Date().toLocaleString() ,'connection closed');
            // this.startConnection();
        })
        this.connection?.onreconnecting((e)=> {
            console.log(new Date().toLocaleString() ,'reconnecting', e);
        });
        this.connection?.onreconnected((id)=> {
            console.log(new Date().toLocaleString() ,'reconnected', id);
        });
        this.connection?.on('imageChanged', (img) => this.imageChangedSubject.next(img));
        this.connection?.on('timeChanged', (img) => this.timeChangedSubject.next(img));
    }



}