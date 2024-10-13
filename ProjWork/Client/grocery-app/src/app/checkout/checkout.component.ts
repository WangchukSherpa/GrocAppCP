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
      console.log("Delivery Method ID changed to:", value); // Debug log
      this.updateDeliveryCharge(value);
    });
  }

  updateDeliveryCharge(selectedMethod: number): void {
    console.log("Updating delivery charge based on method:", selectedMethod); // Debug log
  
    if(selectedMethod==1) this.deliveryCharge=0;
   else if(selectedMethod==2) this.deliveryCharge=15;
   else if(selectedMethod==3) this.deliveryCharge=30;
   else if(selectedMethod==4) this.deliveryCharge=40;
   else if(selectedMethod==5) this.deliveryCharge=50;
    console.log("Updated Delivery Charge:", this.deliveryCharge); // Debug log
  }

  loadBasket(): void {
    this.basketService.getBasket().subscribe(
      (response) => {
        this.basket = response;
        console.log('Loaded basket:', this.basket);
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
    console.log('Form Submission Triggered')

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
      shiptoAddress: {
        FlatHouseNo: this.checkoutForm.get('FlatHouseNo')?.value,
        AreaSector: this.checkoutForm.get('AreaSector')?.value,
        LandMark: this.checkoutForm.get('LandMark')?.value,
        Pincode: this.checkoutForm.get('Pincode')?.value,
        City: this.checkoutForm.get('City')?.value,
        State: this.checkoutForm.get('State')?.value
      }
    };

    this.checkoutService.placeOrder(checkoutData).subscribe({
      next: (response) => {
        console.log('Order placed successfully', response);
        this.router.navigate(['/payment']);
    
      },
      error: (err) => console.error('Order placement failed', err)
    });
  }
}
