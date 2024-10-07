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
    this.basketService.getBasket('ba1').subscribe(
      (basket) => {
        const updatedItems = basket.Items.filter(item => item.Id !== productId);
  
        const updatedBasket: IBasket = {
          ...basket,
          Items: updatedItems
        };
  
        console.log(`Deleting item ${productId} from basket ${basket.Id}`);
  
        this.basketService.removeItemFromBasket(basket.Id, productId).subscribe(
          () => {
            console.log('Item removed from backend, now updating basket:', updatedBasket);
            this.basket = updatedBasket; // Remove from UI without waiting for API call, for smoother user experience
          },
          (error) => {
            console.error('Error removing item from backend:', error);
          }
        );
      },
      (error) => {
        console.error('Error fetching basket:', error);
      }
    );
  }
}
  
