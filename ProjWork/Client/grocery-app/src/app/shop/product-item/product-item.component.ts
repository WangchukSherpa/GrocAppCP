import { Component, Input } from '@angular/core';
import { IProduct } from '../../models/product.model';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.css'
})
export class ProductItemComponent {

  
  @Input() product:IProduct; // Ensure @Input is used for product
}
