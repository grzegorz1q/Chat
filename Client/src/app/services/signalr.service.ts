import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from '../environment';
import { Message } from '../models/message/message.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private hubConnection!: signalR.HubConnection; //Nwm czy powinno być z "!"

  private messageSource = new BehaviorSubject<Message | null>(null); // Nie do końca rozumiem
  message$ = this.messageSource.asObservable();              //

  private readonly apiUrl = `${environment.apiUrl}/messageHub`;
  constructor(){}

  public startConnection = () =>{
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.apiUrl)
      .build();

      this.hubConnection
        .start()
        .then(() => console.log("SignalR connection started"))
        .catch(error => console.error('Error establishing SignalR connection: ' + error));
  }

  public addMessageListener = () => {
    this.hubConnection.on('ReceiveMessage', (message: Message) => {
      this.messageSource.next(message);
    })
  }

  public stopConnection() {
    if (this.hubConnection) {
      this.hubConnection.stop().catch(err => console.error(err));
    }
  }
}
