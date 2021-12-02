import { Basket, IBasket, IBasketItem, IBasketTotal } from './../models/basket';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { IProduct } from '../models/product';
import { IDelivaryMethod } from '../models/delivery';

@Injectable({
  providedIn: 'root'
})
export class BasketService implements OnInit {
  [x: string]: any;
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotal>(null);
   shipping =0 ;
  basketTotal$ = this.basketTotalSource.asObservable();
  constructor(private http: HttpClient  ) { }
  ngOnInit(): void {


  }

  setShippingPrice(deliveryMethod:IDelivaryMethod) {
    this.shipping = deliveryMethod.price;
    this.calculateTotals();
  }
private calculateTotals(){
const basket= this.getCurrentBasketValue();
const shipping =this.shipping;

  const subTotal = basket.items.reduce((a,b)=>
  (b.price*b.quantity) +a,0);
  const total = subTotal+shipping;
  this.basketTotalSource.next({shipping,total,subTotal});



}
  GetBasket(id: string) {
    return this.http.get<IBasket>(this.baseUrl+'basket?id=' + id).pipe(
      map((basket: IBasket) => {
        this.basketSource.next(basket);
        this.calculateTotals();
          })
    );
  }

  SetBasket(basket: IBasket) {
    return this.http.post<IBasket>(this.baseUrl + 'Basket', basket).subscribe(
      (response: IBasket) => {
        this.basketSource.next(response)
        console.log(response);
      }, error => {
        console.log(error);
      })
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemsBasket(item: IProduct, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.CreateBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.SetBasket(basket);
    this.calculateTotals();
  }
  incrementItemQuantity(item:IBasketItem){
const basket = this.getCurrentBasketValue();
const foundItemIndex = basket.items.findIndex(x=>x.id==item.id);
basket.items[foundItemIndex].quantity++;
this.SetBasket(basket);
    this.calculateTotals()
  }

  decrementItemQuantity(item:IBasketItem){
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x=>x.id==item.id);
    if(basket.items[foundItemIndex].quantity >1) {
      basket.items[foundItemIndex].quantity--;
      this.SetBasket(basket);
    } else {
      this.removeItemBasket(item);
    }
    this.calculateTotals()
      }
  removeItemBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
         if( basket.items.some(i=>i.id == item.id)){
          basket.items= basket.items.filter(i=>i.id !== item.id);
          if(basket.items.length>0){
            this.SetBasket(basket);
          }else {
            this.DeleteBasket(basket.id);
  }
  this.calculateTotals();
}}


  addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id == itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    } return items;
  }

  private mapProductToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity: quantity,
      brand: item.productBrand,
      type: item.productType,

    };



  }
private CreateBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;


  }
  deleteLocalBasket(id:string){
    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket_id');

  }

  DeleteBasket(BasketId: string) {
  this.http.delete(this.baseUrl+'basket?id='+ BasketId).subscribe(()=>{

   this.basketSource.next(null);
   this.basketTotalSource.next(null);
   localStorage.removeItem('basket_id');
},error=> {
console.log(error);
});}


}

