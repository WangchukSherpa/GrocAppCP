import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      FirstName: ['', [Validators.required, Validators.minLength(2), Validators.pattern('[a-zA-Z ]*')]],
      LastName: ['', [Validators.required, Validators.minLength(2), Validators.pattern('[a-zA-Z ]*')]],
      Email: ['', [Validators.required, Validators.email]],
      PhoneNum: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      Password: ['', [
        Validators.required,
        Validators.minLength(8),
   
      ]],
      Address: this.formBuilder.group({
        FlatHouseNo: ['', [Validators.required, Validators.minLength(1)]],
        AreaSector: ['', [Validators.required, Validators.minLength(3)]],
        LandMark: ['', [Validators.required, Validators.minLength(3)]],
        Pincode: ['', [Validators.required, Validators.pattern('^[0-9]{6}$')]],
        City: ['', [Validators.required, Validators.minLength(2), Validators.pattern('[a-zA-Z ]*')]],
        State: ['', [Validators.required, Validators.minLength(2), Validators.pattern('[a-zA-Z ]*')]]
      })
    });
  }

  // Getter for easy access to form fields
  get f() { return this.signupForm.controls; }
  get address() { return (this.signupForm.get('Address') as FormGroup).controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.signupForm.invalid) {
      return;
    }

    this.http.post('https://localhost:7275/api/Auth/register', this.signupForm.value, { responseType: 'text' })
      .subscribe({
        next: (response) => {
          if (response === 'Registration successful.') {
            alert('Registration successful!');
            this.router.navigate(['/login']);
          } else {
            alert('Unexpected response: ' + response);
          }
        },
        error: (error) => {
          console.error('Signup failed', error);
          alert('Signup failed: ' + (error.error || 'An error occurred'));
        }
      });
  }

  // Helper method to check if a field has errors
  hasError(field: string, error: string): boolean {
    const control = field.includes('.') 
      ? this.signupForm.get(field)
      : this.signupForm.get(field);
    return !!(control && control.errors?.[error] && (control.dirty || control.touched || this.submitted));
  }
}