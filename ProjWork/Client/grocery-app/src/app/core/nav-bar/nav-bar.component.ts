import { Component, OnInit } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { IBasket } from '../../models/basket.model';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  basket: IBasket;

  constructor(private basketService: BasketService) {}

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
    const basketId = 'ba1'; // Use dynamic ID if needed
    this.basketService.getBasket(basketId).subscribe(
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
}
