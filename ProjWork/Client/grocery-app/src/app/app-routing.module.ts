import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AuthGuard } from './guards/auth.guards';
import { CheckoutComponent } from './checkout/checkout.component';
import { PaymentComponent } from './payment/payment.component';
import { SucessComponent } from './sucess/sucess.component';
import { MyOrderComponent } from './my-order/my-order.component';
const routes: Routes = [
  {path:'',component:HomeComponent,data:{breadcrumb:'Home'}},
  {path:'shop',component:ShopComponent,data:{breadcrumb:'Shop'}},
  {path:'login',component:LoginComponent,data:{breadcrumb:'Login'}},
  {path:'signup',component:SignupComponent,data:{breadcrumb:'SignUp'}},
  {path:'shop/:id',component:ProductDetailsComponent,data:{breadcrumb:{alias:'productDetails'}}},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule),data:{breadcrumb:'Basket'}, canActivate: [AuthGuard]},
  {path:'contact',component:ContactComponent,data:{breadcrumb:'Contact'}},
  {path:'checkout',component:CheckoutComponent,data:{breadcrumb:'Checkout'},canActivate: [AuthGuard]},
  {path:'payment',component:PaymentComponent,data:{breadcrumb:'Payment'},canActivate: [AuthGuard]},
  {path:'sucess',component:SucessComponent,canActivate: [AuthGuard]},
  { path: 'my-orders', component: MyOrderComponent,canActivate: [AuthGuard]},
  {path:'**',redirectTo:'',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
