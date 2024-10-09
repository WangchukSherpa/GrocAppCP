import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../models/basket.model';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class BasketService {
  private baseUrl = 'https://localhost:7275/api/Basket'; 

  constructor(private http: HttpClient) {}

  getBasket(id: string): Observable<IBasket> {
    return this.http.get<IBasket>(`${this.baseUrl}?id=${id}`);
  }

  // addItemToBasket(basket: IBasket): Observable<IBasket> {
  
  //   return this.http.post<IBasket>(this.baseUrl, basket);
  // }
  // removeItemFromBasket(basketId: string, itemId: number): Observable<void> {
  //   const url = `${this.baseUrl}?Id=${basketId}`;
  //   console.log('Making DELETE request to:', url);
  //   return this.http.delete<void>(url);
  // }
  addItemToBasket(basket: IBasket): Observable<IBasket> {
    const token = sessionStorage.getItem('token'); // Get the token from session storage
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`, // Set the Authorization header
      'Content-Type': 'application/json' // Set the Content-Type header if necessary
    });

    return this.http.post<IBasket>(this.baseUrl, basket, { headers });
  }

  removeItemFromBasket(basketId: string, itemId: number): Observable<void> {
    const url = `${this.baseUrl}?Id=${basketId}`;
    console.log('Making DELETE request to:', url);
    return this.http.delete<void>(url);
  }
}
  



