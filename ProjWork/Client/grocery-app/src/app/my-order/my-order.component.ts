import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-my-order',
  templateUrl: './my-order.component.html',
  styleUrl: './my-order.component.css'
})
export class MyOrderComponent {


  orders: any[] = []; // Array to hold the user's orders
  buyerEmail: string | null = ''; // To hold the user's email

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // Get email from session storage
    this.buyerEmail = sessionStorage.getItem('email');

    if (this.buyerEmail) {
      // Fetch orders using the API
      const headers = this.createAuthorizationHeader(); // Create authorization headers
      this.http.get<any[]>(`https://localhost:7275/api/Order/byEmail/${this.buyerEmail}`, { headers }).subscribe(
        (data) => {
          this.orders = data; // Assign fetched data to orders array
        },
        (error) => {
          console.error('Error fetching orders', error);
        }
      );
    } else {
      console.error('No email found in session storage');
    }
  }

  // Function to create authorization headers with JWT token
  private createAuthorizationHeader(): HttpHeaders {
    const token = sessionStorage.getItem('token'); // Get token from session storage
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    if (token) {
      headers = headers.append('Authorization', `Bearer ${token}`);
    }
    return headers;
  }

}
