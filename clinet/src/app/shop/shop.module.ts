import { ShardModule } from './../shard/shard.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent
  ],
  exports:[
    ShopComponent],
  imports: [
    CommonModule,
    ShardModule
  ]
})
export class ShopModule { }
