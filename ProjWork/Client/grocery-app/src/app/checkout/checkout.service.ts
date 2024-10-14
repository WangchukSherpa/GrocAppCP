import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Checkout } from '../models/checkout.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  private baseUrl = 'https://localhost:7275/api/Order';

  constructor(private http: HttpClient) {}

  placeOrder(checkoutData: Checkout): Observable<any> {
    const headers = this.createAuthorizationHeader();
    return this.http.post(this.baseUrl, checkoutData,{headers});
  }
  private createAuthorizationHeader(): HttpHeaders {
    const token = sessionStorage.getItem('token'); // Get token from session storage
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    if (token) {
      headers = headers.append('Authorization', `Bearer ${token}`);
    }
    return headers;
  }
}
