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

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    // Get email from session storage
    this.buyerEmail = sessionStorage.getItem('email');
    
    if (this.buyerEmail) {
      // Fetch order details from the review API with headers
      const headers = this.createAuthorizationHeader();
      this.http.get(`https://localhost:7275/api/Order/byEmail/${this.buyerEmail}`, { headers }).subscribe(
        (data: any) => {
          this.order = data[0]; // Assuming the first order is the one to pay for
          
          // Extract the delivery method details
          if (this.order && this.order.DeliveryMethod) {
            const deliveryMethodId = this.getDeliveryMethodId(this.order.DeliveryMethod);
            this.order.DeliveryMethod = {
              Id: deliveryMethodId,
              Name: this.getDeliveryMethodName(deliveryMethodId),
              Price: this.getDeliveryMethodPrice(deliveryMethodId)
            };
          }
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
    if (this.buyerEmail && this.order) {
      const headers = this.createAuthorizationHeader();
      const paymentUrl = `https://localhost:7275/api/Payment/${this.buyerEmail}`;
  
      // Prepare the payment payload
      const paymentPayload = {
        DeliveryMethodId: this.order.DeliveryMethod.Id,
        DeliveryMethod: {
          Id: this.order.DeliveryMethod.Id,
          Name: this.order.DeliveryMethod.Name,
          Description:"",
          Price: this.order.DeliveryMethod.Price
        }
      };
       console.log(paymentPayload);
      // Call the payment API
      this.http.post(paymentUrl, paymentPayload, { headers }).subscribe(
        (response) => {
          console.log('Payment successful', response);
          alert('Payment successful');
          this.router.navigate(['/success']);
        },
        (error) => {
          console.error('Error processing payment', error);
          alert('Payment failed');
        }
      );
    } else {
      alert('User email or order not found, unable to process payment');
    }
  }
  
  // Utility function to map DeliveryMethod string to ID
  getDeliveryMethodId(deliveryMethodName: string): number {
    const deliveryMethodMap: { [key: string]: number } = {
      'Free': 1,
      'DV1': 2,
      'DV2': 3,
      'DV3': 4,
      'DV4': 5
    };
    return deliveryMethodMap[deliveryMethodName] || 0; // Return 0 if unknown method
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

  // Get delivery method name based on DeliveryMethodId
  getDeliveryMethodName(deliveryMethodId: number): string {
    const deliveryMethods = {
      1: 'Free',
      2: 'DV1',
      3: 'DV2',
      4: 'DV3',
      5: 'DV4'
    };
    return deliveryMethods[deliveryMethodId] || 'Unknown';
  }

  // Get delivery method price based on DeliveryMethodId
  getDeliveryMethodPrice(deliveryMethodId: number): number {
    const deliveryPrices = {
      1: 0.00,
      2: 15.00,
      3: 30.00,
      4: 40.00,
      5: 50.00
    };
    return deliveryPrices[deliveryMethodId] || 0;
  }
}
