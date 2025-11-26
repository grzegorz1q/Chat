import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class JwtService {
  getUserId(){
    const token = localStorage.getItem('token');
    if (!token) return '';

    const payload: any = jwtDecode(token);
    return payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
  }
  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
