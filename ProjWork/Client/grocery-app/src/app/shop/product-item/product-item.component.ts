import { Component, Input } from '@angular/core';
import { IProduct } from '../../models/product.model';
import { IBasket,IBasketItem } from '../../models/basket.model';
import { BasketService } from '../../basket/basket.service';
@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.css'
})
export class ProductItemComponent {

  
  @Input() product:IProduct; // Ensure @Input is used for product
  ;

  constructor(private basketService: BasketService) {}

  addItemToBasket(product: IProduct): void {
    this.basketService.getBasket('ba1').subscribe(
      (basket) => {
        console.log('Fetched basket:', basket);

        const newItem: IBasketItem = {
          Id: product.Id,
          ProductName: product.Name,
          Price: product.Price,
          Quantity: 1,
          PictureUrl: product.PictureUrl,
          Brand: product.ProductBrand.Name,
          Type: product.ProductType.Name,
          CustomersBasketId: basket.Id
        };

        const existingItemIndex = basket.Items.findIndex(item => item.Id === newItem.Id);

        if (existingItemIndex > -1) {
          basket.Items[existingItemIndex].Quantity += 1;
        } else {
          basket.Items.push(newItem);
        }

        console.log('Updated basket before sending:', basket);

        this.basketService.addItemToBasket(basket).subscribe(
          (response) => {
            console.log('Item added to basket:', response);
          },
          (error) => {
            console.error('HTTP error response:', error);
          }
        );
      },
      (error) => {
        console.error('Error fetching basket:', error);
      }
    );
  }

     
}
