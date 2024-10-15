import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { Router } from '@angular/router';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule
  ],
  exports:[HomeComponent]
})
export class HomeModule {
  constructor(private router: Router) {}

 }
