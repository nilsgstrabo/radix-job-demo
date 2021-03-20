import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Subject } from 'rxjs';

@Injectable()
export class NotificationHubService {

  private connection: signalR.HubConnection;
  private imageChangedSubject = new Subject<any>();
  imageChanged = this.imageChangedSubject.asObservable();

  constructor() {
    this.createConnection();
    this.registerServerEvents();
    this.startConnection();
  }

  private createConnection() {
    this.connection = new signalR.HubConnectionBuilder().withUrl('/notificationhub').build();
  }

  private startConnection() {
    this.connection.start().catch(e => console.log(e));
  }

  private registerServerEvents(): void {
    this.connection.on('imageChanged', (img) => this.imageChangedSubject.next(img));
  }

}