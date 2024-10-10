import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginData = { Email: '', Password: '' };

  constructor(private http: HttpClient, private router: Router) {}

  onLogin() {
    this.http.post<{ Token: string }>('https://localhost:7275/api/Auth/login', this.loginData)
      .subscribe(
        response => {
          // Check if the response contains the Token
          if (response.Token) {
            // Store the token in session storage
            sessionStorage.setItem('token', response.Token);
            sessionStorage.setItem('email', this.loginData.Email); // Store the email if needed
            alert('Login Sucessfull!!! Happy Shopping')
  
            // Redirect to the home page or another page
            this.router.navigate(['/home']);
          } else {
            alert('Login failed: JSON Token failed to generate!!!'); 
          }
        },
        error => {
          console.error('Login failed', error);
          alert('Login failed: ' + (error.error?.message || 'An error occurred'));
        }
      );
  }

}
