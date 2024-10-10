import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AuthGuard } from './guards/auth.guards';
const routes: Routes = [
  {path:'',component:HomeComponent,data:{breadcrumb:'Home'}},
  {path:'shop',component:ShopComponent,data:{breadcrumb:'Shop'}},
  {path:'login',component:LoginComponent,data:{breadcrumb:'Login'}},
  {path:'signup',component:SignupComponent,data:{breadcrumb:'SignUp'}},
  {path:'shop/:id',component:ProductDetailsComponent,data:{breadcrumb:{alias:'productDetails'}}},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule),data:{breadcrumb:'Basket'}, canActivate: [AuthGuard]},
  {path:'contact',component:ContactComponent,data:{breadcrumb:'Contact'}},
  {path:'**',redirectTo:'',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
