import { Component, Input, input, OnInit, signal} from '@angular/core';
import { Message } from '../../../../models/message/message.model';
import { DatePipe, NgClass } from '@angular/common';

@Component({
  selector: 'app-chat-container',
  imports: [DatePipe, NgClass],
  templateUrl: './chat-container.component.html',
  styleUrl: './chat-container.component.scss',
})
export class ChatContainerComponent{
  messages = input<Message[]>([]); //signal because list can change dynamically
  @Input() userId!: number; //const value, no need for reactivity
}
