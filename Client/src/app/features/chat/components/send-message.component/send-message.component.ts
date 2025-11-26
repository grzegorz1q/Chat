import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
export class SendMessageComponent implements OnInit {
  message!: CreateMessage;
  @Input() userId!: number; //not visible on UI, no need to be input<>()

  @Output() messageSent = new EventEmitter<CreateMessage>(); //not visible on UI, no need to be output<>()

  ngOnInit() {
    this.message = {
      userId: this.userId,
      content: ''
    };
  }

  sendMessage(){
    this.messageSent.emit(this.message);
    this.message = {
      userId: this.userId,
      content: ''
    }
  }
}
