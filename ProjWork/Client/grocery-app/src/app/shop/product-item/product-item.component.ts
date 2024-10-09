import { Component, Input } from '@angular/core';
import { IProduct } from '../../models/product.model';
import { IBasket, IBasketItem, IBasketPost ,IPost} from '../../models/basket.model';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css' ], // Fixed typo: changed 'styleUrl' to 'styleUrls'
})
export class ProductItemComponent {
  @Input() product: IProduct; // Ensure @Input is used for product

  constructor(private basketService: BasketService) {}

  addItemToBasket(product: IProduct): void {
    const newItem: IBasketPost = {
      ProductName: product.Name,
      Price: product.Price,
      Quantity: 1,
      PictureUrl: product.PictureUrl,
      Brand: product.ProductBrand.Name,
      Type: product.ProductType.Name,
      customersBasketId: sessionStorage.getItem('email'), // Use email from session storage
    };

    // Create payload for the basket
    const payload: IPost = {
      Id: sessionStorage.getItem('email'), // Using email as basket ID
      Items: [newItem],
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
