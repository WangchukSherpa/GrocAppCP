import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  constructor(private router: Router) {}

  logout() {
    // Clear session storage
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('token');
  alert(' You are Logged Out -----See you again!!');
   
    this.router.navigate(['/login']);
 

  }
}
