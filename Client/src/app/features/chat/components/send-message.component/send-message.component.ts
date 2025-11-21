import { Component, EventEmitter, Output } from '@angular/core';
import { Message } from '../../../../models/message.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-send-message',
  imports: [FormsModule],
  templateUrl: './send-message.component.html',
  styleUrl: './send-message.component.scss',
})
export class SendMessageComponent {
  message: Message = {
    userName: '',
    content: '',
    date: Date.now()
  }

  @Output() messageSent = new EventEmitter<Message>();

  sendMessage(){
    this.messageSent.emit(this.message);
    this.message = {
      userName: '',
      content: '',
      date: Date.now()
    }
  }
}
