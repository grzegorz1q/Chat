import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CreateMessage } from '../../../../models/message/create-message';
import { MatInputModule } from '@angular/material/input';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';

@Component({
  selector: 'app-send-message',
  imports: [FormsModule, MatInputModule, CdkTextareaAutosize],
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
      username: this.message.username,
      content: ''
    }
  }
}
