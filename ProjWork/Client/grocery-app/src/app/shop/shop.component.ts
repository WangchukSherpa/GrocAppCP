import { IProduct, IProductBrand, IProductType } from '../models/product.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { ElementRef } from '@angular/core';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {


  // Data related to products, brands, and types
  products: IProduct[] = [];
  brands: IProductBrand[] = [];
  types: IProductType[] = [];

  // Pagination and product display related data
  currentPage: number = 1; // To track the current page
  productsPerPage: number = 10; // Number of products per page
  totalProducts: number = 0; // Total number of products returned
  totalPages: number = 5; // Total number of pages 

  // Filtering and sorting related data
  brandIdSelected: number = 0; // Selected brand ID
  typeIdSelected: number = 0; // Selected type ID
  sortSelected: string = 'name'; // Default sorting by name
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price Low to High', value: 'priceasc' },
    { name: 'Price High to Low', value: 'pricedesc' }
  ];

  search: string = ''; // Search term

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  // Fetch products from API with pagination, filtering, and sorting
  getProducts() {
    const skip = (this.currentPage - 1) * this.productsPerPage;
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected, skip, this.productsPerPage).subscribe(
      (response) => {
        console.log('Products from API:', response);
        this.products = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  // Function to handle page change
  changePage(page: number) {
    this.currentPage = page;
    this.getProducts();
  }

  // Fetch brands from API
  getBrands() {
    this.shopService.getBrands().subscribe(
      (response) => {
        console.log(response);
        this.brands = [{ Id: 0, Name: 'All' }, ...response]; // Add 'All' option
      },
      (error) => {
        console.error(error);
      }
    );
  }

  // Fetch types from API
  getTypes() {
    this.shopService.getTypes().subscribe(
      (response) => {
        console.log(response);
        this.types = [{ Id: 0, Name: 'All' }, ...response]; // Add 'All' option
      },
      (error) => {
        console.error(error);
      }
    );
  }

  // Handle brand selection from dropdown
  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  // Handle type selection from dropdown
  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  // Handle sorting change
  onSortSelected(event: Event) {
    const sort = (event.target as HTMLSelectElement).value;
    this.sortSelected = sort;
    this.getProducts();
  }

 
}
