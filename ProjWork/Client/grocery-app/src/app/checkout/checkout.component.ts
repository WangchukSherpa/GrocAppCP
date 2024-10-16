import { Component, OnInit } from '@angular/core';
import { BasketService } from '../basket/basket.service';
import { IBasket } from '../models/basket.model';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CheckoutService } from './checkout.service';
import { Checkout } from '../models/checkout.model';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'] // Corrected from styleUrl to styleUrls
})
export class CheckoutComponent implements OnInit {
  basket: IBasket;
  checkoutForm: FormGroup;
  deliveryCharge: number = 0;
  useStoredAddress: boolean = false; // New variable to manage address selection
  savedAddress: any;
  orderPlaced = false;
  constructor(
    private basketService: BasketService,
    private fb: FormBuilder,
    private checkoutService: CheckoutService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadBasket();
    this.checkoutForm = this.fb.group({
      FlatHouseNo: ['', Validators.required],
      AreaSector: ['', Validators.required],
      LandMark: ['', Validators.required],
      Pincode: ['', [Validators.required, Validators.minLength(6)]],
      City: ['', Validators.required],
      State: ['', Validators.required],
      DeliveryMethodId: [1, Validators.required] // Default to Free delivery
    });

    // Listen for changes to DeliveryMethodId
    this.checkoutForm.get('DeliveryMethodId')?.valueChanges.subscribe(value => {
      this.updateDeliveryCharge(value);
    });
  }

  updateDeliveryCharge(selectedMethod: number): void {
    if(selectedMethod === 1) this.deliveryCharge = 0;
    else if(selectedMethod === 2) this.deliveryCharge = 15;
    else if(selectedMethod === 3) this.deliveryCharge = 30;
    else if(selectedMethod === 4) this.deliveryCharge = 40;
    else if(selectedMethod === 5) this.deliveryCharge = 50;
  }

  loadBasket(): void {
    this.basketService.getBasket().subscribe(
      (response) => {
        this.basket = response;
      },
      (error) => {
        console.error('Error loading basket:', error);
      }
    );
  }

  getTotalPrice(): number {
    return this.basket?.Items.reduce((sum, item) => sum + item.Price * item.Quantity, 0) || 0;
  }

  getOrderTotal(): number {
    return this.getTotalPrice() + this.deliveryCharge;
  }

  onSubmit(): void {
    if (this.checkoutForm.invalid) {
      return;
    }
    const email = sessionStorage.getItem('email'); 
    if (!email) {
      console.error('No email found in session storage');
      return;
    }

    const checkoutData: Checkout = {
      BasketId: email,
      DeliveryMethodId: this.checkoutForm.get('DeliveryMethodId')?.value,
      shiptoAddress: this.useStoredAddress ? null : {
        FlatHouseNo: this.checkoutForm.get('FlatHouseNo')?.value,
        AreaSector: this.checkoutForm.get('AreaSector')?.value,
        LandMark: this.checkoutForm.get('LandMark')?.value,
        Pincode: this.checkoutForm.get('Pincode')?.value,
        City: this.checkoutForm.get('City')?.value,
        State: this.checkoutForm.get('State')?.value
      }
    };

    this.checkoutService.placeOrder(checkoutData, this.useStoredAddress).subscribe({
      next: (response) => {
        console.log('Order placed successfully', response);
        this.router.navigate(['/payment']);
      },
      error: (err) => console.error('Order placement failed', err)
    });
  }
  onProceedToPay() {
    const email = sessionStorage.getItem('email'); 
    if (this.useStoredAddress) {
      // Call your service to proceed to payment using saved address
      this.checkoutService.placeOrder({
        BasketId: email,
        DeliveryMethodId: this.checkoutForm.value.DeliveryMethodId || 1, // Default to the first method if not set
        shiptoAddress: null
      },this.useStoredAddress).subscribe(response => {
        console.log('Order placed successfully', response);
      
        this.savedAddress = response.ShipToAddress; // Store the saved address details
        this.orderPlaced = true; // Set order placed flag
        // Optional: You can set a timeout before redirecting to the payment page
        setTimeout(() => {
          this.router.navigate(['/payment']); // Redirect to payment page after delay
        }, 3000); // Redirect after 3 seconds, adjust as needed
      }, error => {
        console.error('Error placing order', error);
      });
    }
  }
}
