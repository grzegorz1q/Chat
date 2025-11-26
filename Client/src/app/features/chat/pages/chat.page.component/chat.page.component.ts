import { Component, OnDestroy, OnInit, signal } from '@angular/core';
import { ChatContainerComponent } from '../../components/chat-container.component/chat-container.component';
import { SendMessageComponent } from '../../components/send-message.component/send-message.component';
import { Message } from '../../../../models/message/message.model';
import { MessageService } from '../../../../services/message.service';
import { CreateMessage } from '../../../../models/message/create-message';
import { SignalrService } from '../../../../services/signalr.service';
import { JwtService } from '../../../../services/jwt.service';

@Component({
  selector: 'app-chat.page.component',
  imports: [ChatContainerComponent, SendMessageComponent],
  templateUrl: './chat.page.component.html',
  styleUrl: './chat.page.component.scss',
})
export class ChatPageComponent implements OnInit, OnDestroy {
  messages = signal<Message[]>([]);

  constructor(
    private messageService: MessageService, 
    private signalrService: SignalrService, 
    private jwtService: JwtService){}

  ngOnInit(){
    this.getAllMessages();
    this.signalrService.startConnection();
    this.signalrService.addMessageListener();
    this.signalrService.message$.subscribe(newMessage => {
      if(newMessage){
        console.log(newMessage);
        this.messages.update(old => [...old, newMessage]);
      }
    });
  }

  getAllMessages(){
    this.messageService.getAllMessages().subscribe({
      next: response => {
        this.messages.set(response);
        console.log(this.messages());
      },
      error: error => console.error(error)
    });
  }
  createMessage(message: CreateMessage){
    this.messageService.createMessage(message).subscribe({
      next: response => console.log(response),
      error: error => console.error(error)
    });
  }
  getUserId(): number{
    return this.jwtService.getUserId();
  }
  ngOnDestroy() {
    this.signalrService.stopConnection();
  }
}
