import { Component, OnInit } from '@angular/core';
import { IProduct } from '../../models/product.model';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from '../../basket/basket.service';
import { IBasket, IBasketItem } from '../../models/basket.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'] // Corrected the property name to styleUrls
})
export class ProductDetailsComponent implements OnInit {
  
  product: IProduct;
  quantity: number = 1; // Quantity for the product

  constructor(
    private shopService: ShopService,
    private activeRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private basketService: BasketService // Added basket service
  ) {}

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct(): void {
    this.shopService.getProductById(+this.activeRoute.snapshot.paramMap.get('id')).subscribe(response => {
      this.product = response;
      this.bcService.set('@productDetails', 'Shop / ' + this.product.Name);
    }, error => {
      console.log(error);
    });
  }

  increaseQuantity(): void {
    this.quantity += 1;
  }

  decreaseQuantity(): void {
    if (this.quantity > 1) {
      this.quantity -= 1;
    }
  }

  addToCart(): void {
    const newItem: IBasketItem = {
      Id: this.product.Id,
      ProductName: this.product.Name,
      Price: this.product.Price,
      Quantity: this.quantity,
      PictureUrl: this.product.PictureUrl,
      Brand: this.product.ProductBrand.Name,
      Type: this.product.ProductType.Name,
      customersBasketId: 'ba1' // Ensure the basket ID is correct
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
