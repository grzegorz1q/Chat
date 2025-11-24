import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CreateMessage } from '../../../../models/message/create-message';
import { MatInputModule } from '@angular/material/input';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { JwtService } from '../../../../services/jwt.service';

@Component({
  selector: 'app-send-message',
  imports: [FormsModule, MatInputModule, CdkTextareaAutosize],
  templateUrl: './send-message.component.html',
  styleUrl: './send-message.component.scss',
})
export class SendMessageComponent implements OnInit {
  message!: CreateMessage;

  @Output() messageSent = new EventEmitter<CreateMessage>();

  constructor(private jwtService: JwtService){}

  ngOnInit() {
      this.message = {
        userId: this.jwtService.getUserId(),
        content: ''
      };
  }

  sendMessage(){
    this.messageSent.emit(this.message);
    this.message = {
      userId: this.jwtService.getUserId(),
      content: ''
    }
  }
}
