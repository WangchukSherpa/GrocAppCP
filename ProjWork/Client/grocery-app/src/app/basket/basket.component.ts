import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket.service';
import { IProduct } from '../models/product.model';
import { IBasket, IBasketItem } from '../models/basket.model';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css'],
})
export class BasketComponent implements OnInit {
  basket: IBasket;

  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.loadBasket();
  }

  loadBasket(): void {
    const basketId = 'ba1'; // Use dynamic ID if needed
    this.basketService.getBasket(basketId).subscribe(
      (response) => {
        this.basket = response;
        console.log('Loaded basket:', this.basket);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  removeItemFromBasket(productId: number): void {
  
    this.basketService.removeItemFromBasket(productId).subscribe(
      () => {
        // Update the basket on the client side
        this.basket.Items = this.basket.Items.filter(item => item.Id !== productId);
        console.log('Item removed from basket:', this.basket);
      },
      (error) => {
        console.error('Error removing item from backend:', error);
      }
    );
  }
  getTotalPrice(): number {
    return this.basket?.Items.reduce((sum, item) => sum + item.Price * item.Quantity, 0) || 0;
  }


  updateBasket(): void {
    this.basketService.addItemToBasket(this.basket).subscribe(
      (response) => {
        this.basket = response;
        console.log('Basket updated:', this.basket);
      },
      (error) => {
        console.error('HTTP error response:', error);
      }
    );
  }
  
}
  
