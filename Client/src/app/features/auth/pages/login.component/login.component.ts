import { Component } from '@angular/core';
import { AuthService } from '../../../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  loginDto = {
    username: '',
    password: ''
  };
  error: string | null = null;
  constructor(private authService: AuthService, private router: Router){}

  login(){
    const {username, password} = this.loginDto;
    this.authService.login(username, password).subscribe({
      next: repsonse =>{
        localStorage.setItem('token', repsonse.token);
        this.router.navigateByUrl('/');
      },
      error: error => this.error = error.error //Change backend error to polish language
    });
  }
}
