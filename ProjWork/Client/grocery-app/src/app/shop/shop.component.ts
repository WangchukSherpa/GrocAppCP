import { IProduct, IProductBrand, IProductType } from '../models/product.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import {   ElementRef } from '@angular/core';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {
  @ViewChild('searchTerm', { static: true }) searchTerm: ElementRef;
  products: IProduct[] ;
  brands: IProductBrand[];
  types:IProductType[];
   brandIdSelected: number=0;
 typeIdSelected:number=0;
 sortSelected='name';
 sortOptions=[
  {name:'Alphabetical',value:'name'},
  {name:'Price Low to High',value:'priceasc'},
  {name:'Price:High to Low',value:'pricedesc'}
 ];
 search:string;
  constructor(private shopService: ShopService) {}

  ngOnInit(): void {

    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(){
    this.shopService.getProducts(this.brandIdSelected,this.typeIdSelected,this.sortSelected).subscribe(
      (response) => {
        console.log(response); // This will log the response in the console
        this.products = response; // Assign the response directly to the products array
      },
      (error) => {
        console.error(error); // Log any error
      }
    );
  }

  getBrands(){
    this.shopService.getBrands().subscribe(
      (response) => {
        console.log(response); // This will log the response in the console
        this.brands = [{Id:0,Name:'All'}, ...response]; //  Ability to select all of the types and kind of resets the filter 
      },
      (error) => {
        console.error(error); // Log any error
      }
    );
  }

  getTypes(){
    this.shopService.getTypes().subscribe(
      (response) => {
        console.log(response); // This will log the response in the console
        this.types =  [{Id:0,Name:'All'}, ...response]; //  Ability to select all of the types and kind of resets the filter 
      },
      (error) => {
        console.error(error); // Log any error
      }
    );
  }

  onBrandSelected(brandId:number){
    this.brandIdSelected=brandId;
    this.getProducts();
  }
  onTypeSelected(typeId:number){
    this.typeIdSelected=typeId;
    this.getProducts();
  }

  onSortSelected(event: Event) {
    const sort = (event.target as HTMLSelectElement).value; // Cast to HTMLSelectElement to safely access `value`
    this.sortSelected = sort;
    this.getProducts(); // Call the getProducts method after sort selection
  }


  onSearch() {
    this.search = this.searchTerm.nativeElement.value;
    this.getProducts();
}

onReset() {
    this.searchTerm.nativeElement.value = '';
    this.search = '';
    this.getProducts();
}

}
