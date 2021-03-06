import { NavigationExtras, Router } from '@angular/router';
import { IOrder, IOrderToCreate } from './../../models/order';
import { ToastrService } from 'ngx-toastr';
import { CheckoutService } from './../checkout.service';
import { BasketService } from 'src/app/basket/basket.service';
import { FormGroup } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';
import { IBasket } from 'src/app/models/basket';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements OnInit {
@Input() checkoutForm :FormGroup;
  constructor(private basketService:BasketService ,
     private checkoutService:CheckoutService,
     private toastrService:ToastrService,
     private route:Router) {

  }

  ngOnInit(): void {
  }
submitOrder(){
  const basket = this.basketService.getCurrentBasketValue();
  const orderToCreate = this.getOrderToCreate(basket);
  this.checkoutService.createOrder(orderToCreate).subscribe((order:IOrder)=>{
  this.toastrService.success('Order created successfully');
  this.basketService.deleteLocalBasket(basket.id);
  const navigation:NavigationExtras={state: order};
  this.route.navigate(['checkout/success'],navigation);
  console.log(order);
  } ,error  => {
    this.toastrService.error(error.message);
    console.log(error);
  });
}
  getOrderToCreate(basket: IBasket) : IOrderToCreate{
    return  {
      basketId: basket.id,
      deliveryMethodId:+this.checkoutForm.get('deliveryForm').get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('AddressForm').value
    };
  }
}
