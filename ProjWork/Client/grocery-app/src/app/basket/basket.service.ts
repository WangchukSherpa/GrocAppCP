import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { IBasket, IBasketItem } from '../models/basket.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  private baseUrl = 'https://localhost:7275/api/Basket'; 
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) {}

  // Get the basket and update basketSource
  getBasket(id: string): Observable<IBasket> {
    return this.http.get<IBasket>(`${this.baseUrl}?id=${id}`).pipe(
      map((basket: IBasket) => {
        this.basketSource.next(basket); // Update basketSource
        return basket;
      })
    );
  }

  // Add item to basket and update basketSource
  addItemToBasket(basket: IBasket): Observable<IBasket> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<IBasket>(this.baseUrl, basket, { headers }).pipe(
      map((updatedBasket: IBasket) => {
        this.basketSource.next(updatedBasket); // Update basketSource
        return updatedBasket;
      })
    );
  }

  // Remove item from basket and update basketSource
  removeItemFromBasket(productId: number): Observable<void> {
    const url = `${this.baseUrl}?Id=${productId}`;
    console.log('Making DELETE request to:', url);
    return this.http.delete<void>(url).pipe(
      map(() => {
        const currentBasket = this.basketSource.value;
        if (currentBasket) {
          // Remove the item from the current basket and update basketSource
          currentBasket.Items = currentBasket.Items.filter(item => item.Id !== productId);
          this.basketSource.next(currentBasket); // Update basketSource State manager
        }
      })
    );
  }
}
