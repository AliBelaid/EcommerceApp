import { NavBarComponent } from './nav-bar/nav-bar.component';
 import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
    NavBarComponent
  ],
  exports:[NavBarComponent],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
