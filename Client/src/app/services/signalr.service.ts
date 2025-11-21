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

  private messagesSource = new BehaviorSubject<Message[]>([]); // Nie do końca rozumiem
  messages$ = this.messagesSource.asObservable();              //

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
        this.addMessageListener();
  }

  public addMessageListener = () => {
    this.hubConnection.on('ReceiveMessage', (message: Message) => {
      const currentMessages = this.messagesSource.value;
      this.messagesSource.next([...currentMessages, message]);
    })
  }

  public stopConnection() {
    if (this.hubConnection) {
      this.hubConnection.stop().catch(err => console.error(err));
    }
  }
}
