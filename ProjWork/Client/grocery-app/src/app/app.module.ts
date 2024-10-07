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

@NgModule({
  declarations: [
    AppComponent,
    BasketComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    ShopModule,
    HomeModule,
    ContactModule

    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
