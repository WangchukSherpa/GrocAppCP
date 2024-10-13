import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ShopModule } from './shop/shop.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { HomeComponent } from './home/home.component';
import { HomeModule } from './home/home.module';
import { ContactComponent } from './contact/contact.component';
import { ContactModule } from './contact/contact.module';
import { BasketComponent } from './basket/basket.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { CheckoutComponent } from './checkout/checkout.component';

export function tokenGetter() {
  return localStorage.getItem("token"); // This function retrieves the token from localStorage
}

@NgModule({
  declarations: [
    AppComponent,
    BasketComponent,
    LoginComponent,
    SignupComponent,
    CheckoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    ShopModule,
    HomeModule,
    ContactModule, 
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7275"],  // Replace this with your backend's domain
        disallowedRoutes: [
          "http://localhost:7275/api/auth/login",  // Add your public routes here
          "http://localhost:7275/api/auth/signup",
          "http://localhost:7275/api/auth/shop"

        ]
      }
    })
  
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
