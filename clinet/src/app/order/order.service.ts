import { IOrder } from './../models/order';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }


  getOrders(){
    return this.http.get<IOrder[]>(this.baseUrl +'orders').pipe( map(response => {
      return response;
    }))
    ;
  }
  getOrderId(id:number){
    console.log("this get id " +id);
    return this.http.get<IOrder>(this.baseUrl +'orders/'+id).pipe(map(response => {
      return response;
    }))
    ;
  }



}
