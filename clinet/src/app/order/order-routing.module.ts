import { OrderDetaliedComponent } from './order-detalied/order-detalied.component';
import { OrderComponent } from './order.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{
  path:'',component:OrderComponent
},{
  path:':id',component:OrderDetaliedComponent,data:{breadcrumb:{alias:'OrderDetailed'}}
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
