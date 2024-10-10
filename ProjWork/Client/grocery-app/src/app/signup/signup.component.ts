import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

  signupData = { FirstName: '', LastName: '', Email: '', PhoneNum: '', Password: '' };

  constructor(private http: HttpClient, private router: Router) {}
  onSubmit() {
    console.log(this.signupData);

    this.http.post('https://localhost:7275/api/Auth/register', this.signupData, { responseType: 'text' })
      .subscribe(
        response => {
          // Check if the response contains the success message
          if (response === 'Registration successful.') {
            // Trigger the alert
            alert('Registration successful!');

            // Redirect to the login page after successful registration
            this.router.navigate(['/login']);
          } else {
            
            alert('Unexpected response: ' + response);
          }
        },
        error => {
          // Handle error response from the API
          console.error('Signup failed', error);
          alert('Signup failed: ' + (error.error || 'An error occurred'));
        }
      );
  }
}
