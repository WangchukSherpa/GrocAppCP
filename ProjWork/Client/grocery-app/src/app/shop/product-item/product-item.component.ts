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
    const newItem: IBasketItem = {
      Id: product.Id,
      ProductName: product.Name,
      Price: product.Price,
      Quantity: 1,
      PictureUrl: product.PictureUrl,
      Brand: product.ProductBrand.Name,
      Type: product.ProductType.Name,
      customersBasketId: 'ba1'
    };
  
    const payload: IBasket = {
      Id: 'ba1',
      Items: [newItem]
    };
  
    console.log('Payload before sending:', payload);
  
    this.basketService.addItemToBasket(payload).subscribe(
      (response) => {
        console.log('Item added to basket:', response);
      },
      (error) => {
        console.error('HTTP error response:', error);
      }
    );
  }
  
     
}
