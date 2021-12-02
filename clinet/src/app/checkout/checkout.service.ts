import { IOrder, IOrderToCreate } from './../models/order';
import { AccountService } from 'src/app/account/account.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from './../../environments/environment';
import { IDelivaryMethod } from '../models/delivery';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;
    constructor(private http: HttpClient,private accountService:AccountService) { }

  getDelivaryMethods(){
return this.http.get<IDelivaryMethod[]>(this.baseUrl+'Orders/deliveryMethods').pipe(
  map((dm:IDelivaryMethod[])=>{
    return dm.sort((a,b)=> b.price-a.price);
  }));
  }

createOrder(order:IOrderToCreate) {
return  this.http.post<IOrder>(this.baseUrl +'orders', order);
}

}
