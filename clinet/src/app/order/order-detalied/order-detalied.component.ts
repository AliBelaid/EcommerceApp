import { OrderService } from './../order.service';
import { IOrder, IOrderItem } from './../../models/order';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { BreadcrumbService } from 'xng-breadcrumb';
import { isJSDocThisTag } from 'typescript';

@Component({
  selector: 'app-order-detalied',
  templateUrl: './order-detalied.component.html',
  styleUrls: ['./order-detalied.component.scss']
})
export class OrderDetaliedComponent implements OnInit {
   order:IOrder ;


  constructor( private breadcrumbServices:BreadcrumbService
    ,private activeRoute:ActivatedRoute,
    private orderService:OrderService) {
      this.breadcrumbServices.set('@OrderDetailed',' ');
    }

  ngOnInit(): void {

   let id =this.activeRoute.snapshot.paramMap.get('id');
   console.log(id);
    this.orderService.getOrderId(Number(this.activeRoute.snapshot.paramMap.get('id'))).subscribe(order=>{
      this.order= order  as IOrder;

      this.breadcrumbServices.set('@OrderDetailed',this.order.id+"-"+order.status);
  },error => {
    console.log(error);
  });

  }

}
