import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { IBasket } from '../models/basket.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})

export class BasketService {
  basket: IBasket;
  shippingCharge: number = 50;
  total:number;
  private baseUrl = 'https://localhost:7275/api/Basket'; 
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) {}
  


  // Get the basket by email and update basketSource
  getBasket(): Observable<IBasket> {
    const email = sessionStorage.getItem('email'); // Get email from session storage
    if (!email) {
      throw new Error('Email is not stored in session storage.');
    }

    const headers = this.createAuthorizationHeader(); // Add Authorization header
    return this.http.get<IBasket>(`${this.baseUrl}/${email}`, { headers }).pipe(
      map((basket: IBasket) => {
        this.basketSource.next(basket); // Update basketSource
        return basket;
      })
    );
  }

  // Add or update the basket
  addItemToBasket(basket: IBasket): Observable<IBasket> {
    const headers = this.createAuthorizationHeader(); // Add Authorization header
    return this.http.post<IBasket>(this.baseUrl, basket, { headers }).pipe(
      map((updatedBasket: IBasket) => {
        this.basketSource.next(updatedBasket); // Update basketSource
        return updatedBasket;
      })
    );
  }

  // Remove item from basket using item ID
  removeItemFromBasket(itemId: number): Observable<void> {
    const headers = this.createAuthorizationHeader(); // Add Authorization header
    const url = `${this.baseUrl}/items/${itemId}`; // Use new DELETE endpoint
    console.log('Making DELETE request to:', url);
    return this.http.delete<void>(url, { headers }).pipe(
      map(() => {
        const currentBasket = this.basketSource.value;
        if (currentBasket) {
          // Remove the item from the current basket and update basketSource
          currentBasket.Items = currentBasket.Items.filter(item => item.Id !== itemId);
          this.basketSource.next(currentBasket); // Update basketSource
        }
      })
    );
  }

  // Helper function to create headers with the Authorization token
  private createAuthorizationHeader(): HttpHeaders {
    const token = sessionStorage.getItem('token'); // Get token from session storage
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    if (token) {
      headers = headers.append('Authorization', `Bearer ${token}`);
    }
    return headers;
  }
}
