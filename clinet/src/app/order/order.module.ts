import { BasketSummaryComponent } from './../shard/components/basket-summary/basket-summary.component';

import { ShardModule } from './../shard/shard.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from './order-routing.module';
import { OrderTotalComponent } from '../shard/components/order-total/order-total.component';
import { OrderDetaliedComponent } from './order-detalied/order-detalied.component';
import { OrderComponent } from './order.component';


@NgModule({
  declarations: [
    OrderDetaliedComponent,
    OrderComponent,
  ],
  imports: [
    CommonModule,
    OrderRoutingModule,
ShardModule
  ],
  exports:[
    OrderRoutingModule,

  ]
})
export class OrderModule { }
