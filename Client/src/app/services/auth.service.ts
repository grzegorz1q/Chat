import { Injectable } from '@angular/core';
import { environment } from '../environment';
import { RegisterUser } from '../models/user/register-user.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = `${environment.apiUrl}/auth`;
  
  constructor(private http: HttpClient){}

  login(username: string, password: string):Observable<{token: string}> {
    return this.http.post<{token: string}>(`${this.apiUrl}/login`, {username, password});
  }
  register(user: RegisterUser){
    return this.http.post(`${this.apiUrl}/register`, user);
  }
}
