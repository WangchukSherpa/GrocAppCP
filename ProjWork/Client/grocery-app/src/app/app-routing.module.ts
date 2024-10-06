import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ContactComponent } from './contact/contact.component';

const routes: Routes = [
  {path:'',component:HomeComponent,data:{breadcrumb:'Home'}},
  {path:'shop',component:ShopComponent,data:{breadcrumb:'Shop'}},
  {path:'shop/:id',component:ProductDetailsComponent,data:{breadcrumb:{alias:'productDetails'}}},
  {path:'contact',component:ContactComponent,data:{breadcrumb:'Contact'}},
  {path:'**',redirectTo:'',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
