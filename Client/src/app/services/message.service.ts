import { Injectable } from '@angular/core';
import { environment } from '../environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Message } from '../models/message/message.model';
import { CreateMessage } from '../models/message/create-message';
import { JwtService } from './jwt.service';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private readonly apiUrl = `${environment.apiUrl}/messages`;

  constructor(private http: HttpClient, private jwtService: JwtService){}

  getAllMessages(): Observable<Message[]>{
    return this.http.get<Message[]>(`${this.apiUrl}`);
  }
  createMessage(message: CreateMessage): Observable<number>{
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.jwtService.getToken()}`);
    return this.http.post<number>(`${this.apiUrl}`, message, {headers});
  }
}
