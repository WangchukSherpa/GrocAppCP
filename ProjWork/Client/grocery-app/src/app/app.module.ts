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
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    BasketComponent,
    LoginComponent,
    SignupComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    ShopModule,
    HomeModule,
    ContactModule,
    FormsModule

    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
