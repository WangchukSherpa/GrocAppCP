import { Component, OnInit } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { IBasket } from '../../models/basket.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  basket: IBasket;

  constructor(private basketService: BasketService,private router: Router) {}

  ngOnInit(): void {
    this.basketService.basket$.subscribe(
      (basket) => {
        this.basket = basket;
        console.log('Basket updated:', this.basket); // Log the updated basket
      },
      (error) => {
        console.error(error);
      }
    );

    // Load the basket to trigger the subscription
    this.loadBasket();
  }

  loadBasket(): void {
    
    this.basketService.getBasket().subscribe(
      (response) => {
        console.log('Basket loaded:', response); // Log the response to check if basket is loaded
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getCartItemCount(): number {
    console.log('Calculating cart item count:', this.basket?.Items.length || 0); // Log item count calculation
    return this.basket?.Items.length || 0;
  }
  logout() {
    // Clear session storage
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('token');
  alert(' You are Logged Out -----See you again!!');
   
    this.router.navigate(['/login']);
 

  }
  isLoggedIn(): boolean {
    
    if(sessionStorage.getItem('email')) return true;
    else return false;
  }
  getUserFirstName(): string {
    const email = sessionStorage.getItem('email');
    if (email) {
      const name = email.split('@')[0]; // Split email at '@' and get the first part
      //console.log(name);
      return name; 
    }
    return ''; 
  }

 
}
