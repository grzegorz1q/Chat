import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../../services/auth.service';
import { RegisterUser } from '../../../../models/user/register-user.model';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  user: RegisterUser = {
    username: '',
    password: '',
    confirmPassword: ''
  }
  isLoading: boolean = false;
  message: string | null = null;
  error: string | null = null;

  constructor(private authService: AuthService){}

  register(){
    this.isLoading = true;
    this.authService.register(this.user).subscribe({
      next: () => {
        this.error = null;
        this.message = "Zarejestrowano pomyślnie";
        this.isLoading = false;
      },
      error: error => {
        console.error(error);
        this.error = "Błąd podczas rejestracji"; //maybe change backend errors to polish language and show it here.
        this.isLoading = false;
      }
    });
  }
}
