import { Component, OnInit } from '@angular/core';
import { IProduct } from '../../models/product.model';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit {
  
  product:IProduct;

  constructor(private shopService:ShopService,private activeRoute:ActivatedRoute, private bcService:BreadcrumbService){

  }

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct(){
    this.shopService.getProductById(+this.activeRoute.snapshot.paramMap.get('id')).subscribe(response=>{
      this.product=response;
      this.bcService.set('@productDetails','Shop / '+this.product.Name);

    },error=>{
      console.log(error);
    });
  }

}
