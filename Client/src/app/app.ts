import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ChatContainerComponent } from "./features/chat/components/chat-container.component/chat-container.component";
import { SendMessageComponent } from './features/chat/components/send-message.component/send-message.component';
import { Message } from './models/message.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ChatContainerComponent, SendMessageComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'Chat';

  messages = signal<Message[]>([]);

  getMessage(message: Message){
    this.messages.update(m => [...m, message]);
  }
}
