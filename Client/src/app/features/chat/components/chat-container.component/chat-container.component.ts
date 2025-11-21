import { Component, input} from '@angular/core';
import { Message } from '../../../../models/message.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-chat-container',
  imports: [DatePipe],
  templateUrl: './chat-container.component.html',
  styleUrl: './chat-container.component.scss',
})
export class ChatContainerComponent {
messages = input<Message[]>([]);
}
