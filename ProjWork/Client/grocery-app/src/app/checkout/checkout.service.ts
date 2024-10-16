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

  placeOrder(checkoutData: Checkout, useStoredAddress: boolean): Observable<any> {
    const headers = this.createAuthorizationHeader();
    const url = `${this.baseUrl}?useStoredAddress=${useStoredAddress}`;
    
    // When using saved address, send shiptoAddress as null
    if (useStoredAddress) {
      checkoutData.shiptoAddress = null;
    }

    return this.http.post(url, checkoutData, { headers });
  }

  private createAuthorizationHeader(): HttpHeaders {
    const token = sessionStorage.getItem('token');
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    if (token) {
      headers = headers.append('Authorization', `Bearer ${token}`);
    }
    return headers;
  }
}
