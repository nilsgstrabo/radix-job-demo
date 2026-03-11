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

    private timerInterval?: number;

    constructor() {
        this.createConnection();
        this.registerServerEvents();
        this.startConnection();
        this.startTimer();
    }

    private createConnection() {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl('/notificationhub', signalR.HttpTransportType.WebSockets)
            .build();

        this.connection.serverTimeoutInMilliseconds=10*1000;
        this.connection.keepAliveIntervalInMilliseconds=5*1000;
    }

    private startConnection() {
        this.connection?.start().then(() => console.log(new Date().toLocaleString(), 'connection started')).catch(e => console.log(e));
    }

    private registerServerEvents(): void {
        this.connection?.onclose((e)=> {
            console.log(new Date().toLocaleString() ,'connection closed');
            this.stopTimer();
            // this.startConnection();
        })
        this.connection?.onreconnecting((e)=> {
            console.log(new Date().toLocaleString() ,'reconnecting', e);
        });
        this.connection?.onreconnected((id)=> {
            console.log(new Date().toLocaleString() ,'reconnected', id);
            this.startTimer();
        });
        this.connection?.on('imageChanged', (img) => this.imageChangedSubject.next(img));
        this.connection?.on('timeChanged', (img) => this.timeChangedSubject.next(img));
    }

    private startTimer(): void {
        this.stopTimer();
        this.timerInterval = window.setInterval(() => {
            const message = `Timer ping at ${new Date().toISOString()}`;
            this.connection?.invoke('ReceiveTimerMessage', message)
                .catch(err => console.error('Error sending timer message:', err));
        }, 5000); // Send message every 10 seconds
    }

    private stopTimer(): void {
        if (this.timerInterval) {
            clearInterval(this.timerInterval);
            this.timerInterval = undefined;
        }
    }

}