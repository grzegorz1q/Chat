import { Injectable } from '@angular/core';
import { environment } from '../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Message } from '../models/message/message.model';
import { CreateMessage } from '../models/message/create-message';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private readonly apiUrl = `${environment.apiUrl}/messages`;

  constructor(private http: HttpClient){}

  getAllMessages(): Observable<Message[]>{
    return this.http.get<Message[]>(`${this.apiUrl}`);
  }
  createMessage(message: CreateMessage): Observable<number>{
    return this.http.post<number>(`${this.apiUrl}`, message);
  }
}
