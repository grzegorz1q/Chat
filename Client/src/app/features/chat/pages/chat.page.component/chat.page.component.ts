import { Component, OnInit, signal } from '@angular/core';
import { ChatContainerComponent } from '../../components/chat-container.component/chat-container.component';
import { SendMessageComponent } from '../../components/send-message.component/send-message.component';
import { Message } from '../../../../models/message/message.model';
import { MessageService } from '../../../../services/message.service';
import { CreateMessage } from '../../../../models/message/create-message';

@Component({
  selector: 'app-chat.page.component',
  imports: [ChatContainerComponent, SendMessageComponent],
  templateUrl: './chat.page.component.html',
  styleUrl: './chat.page.component.scss',
})
export class ChatPageComponent implements OnInit {
  messages = signal<Message[]>([]);

  constructor(private messageService: MessageService){}

  ngOnInit(){
    this.getAllMessages();
  }

  getAllMessages(){
    this.messageService.getAllMessages().subscribe({
      next: response => this.messages.set(response),
      error: error => console.error(error)
    });
  }
  createMessage(message: CreateMessage){
    this.messageService.createMessage(message).subscribe({
      next: response => console.log(response),
      error: error => console.error(error)
    });
  }
}
