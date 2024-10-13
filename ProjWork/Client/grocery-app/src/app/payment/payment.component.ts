import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  order: any;
  paymentDetails = {
    cardName: '',
    cardNumber: '',
    cvv: ''
  };
  buyerEmail: string | null = '';
  
  constructor(private http: HttpClient,
    private router:Router
  ) {}

  ngOnInit(): void {
    // Get email from session storage
    this.buyerEmail = sessionStorage.getItem('email');
    
    if (this.buyerEmail) {
      // Fetch order details from the review API with headers
      const headers = this.createAuthorizationHeader();
      this.http.get(`https://localhost:7275/api/Order/byEmail/${this.buyerEmail}`, { headers }).subscribe(
        (data: any) => {
          this.order = data[0]; // Assuming the first order is the one to pay for
        },
        (error) => {
          console.error('Error fetching order details', error);
        }
      );
    } else {
      console.error('No email found in session storage');
    }
  }

  onSubmit(): void {
    // Check if the email is available in session storage
    if (this.buyerEmail) {
      const headers = this.createAuthorizationHeader();
      const paymentUrl = `https://localhost:7275/api/Payment/${this.buyerEmail}`;
      
      // Call the Stripe payment API without body (just a POST request) and headers
      this.http.post(paymentUrl, {}, { headers }).subscribe(
        (response) => {
          console.log('Payment successful', response);
          alert('Payment successful');
           this.router.navigate(['/sucess']);
        },
        (error) => {
          console.error('Error processing payment', error);
          alert('Payment failed');
        }
      );
    } else {
      alert('User email not found, unable to process payment');
    }
  }

  // Create authorization headers with the token from session storage
  private createAuthorizationHeader(): HttpHeaders {
    const token = sessionStorage.getItem('token'); // Get token from session storage
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    if (token) {
      headers = headers.append('Authorization', `Bearer ${token}`);
    }
    return headers;
  }
}
