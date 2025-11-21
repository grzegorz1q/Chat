import { Component, EventEmitter, Output } from '@angular/core';
import { Message } from '../../../../models/message/message.model';
import { FormsModule } from '@angular/forms';
import { CreateMessage } from '../../../../models/message/create-message';

@Component({
  selector: 'app-send-message',
  imports: [FormsModule],
  templateUrl: './send-message.component.html',
  styleUrl: './send-message.component.scss',
})
export class SendMessageComponent {
  message: CreateMessage = {
    username: '',
    content: ''
  }

  @Output() messageSent = new EventEmitter<CreateMessage>();

  sendMessage(){
    this.messageSent.emit(this.message);
    this.message = {
      username: '',
      content: ''
    }
  }
}
