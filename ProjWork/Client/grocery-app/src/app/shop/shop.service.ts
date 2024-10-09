import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct, IProductBrand, IProductType } from '../models/product.model';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:7275/api/'
  constructor(private http:HttpClient) { }
  getProducts(brandId?:number ,typeId?:number,sort?:string){
    let params=new HttpParams();
    if(brandId){
      params=params.append('productbrandId',brandId.toString());
    }
    if(typeId)
      {
        params = params.append('productTypeId', typeId.toString());
    }
    if(sort){
      params=params.append('sortBy',sort);
    }



    return this.http.get<IProduct[]>(this.baseUrl+'Products', {observe:'response',params} )
    .pipe(
      map(response=>{
        return response.body;
      })
    );
   
    }
    // https://localhost:7275/api/Products/3
    // getProductById(id:number){
    //   return this.http.get<IProduct>(this.baseUrl+'Products/'+id);
    // }
    getProductById(id: number) {
      const url = `${this.baseUrl}Products/${id}`;
      console.log(`Requesting URL: ${url}`);
      return this.http.get<IProduct>(url);
    }
    
    getBrands(){
      return this.http.get<IProductBrand[]>(this.baseUrl+'Products/brands');
    }
    getTypes(){
      return this.http.get<IProductType[]>(this.baseUrl+'Products/types');
    }
}
