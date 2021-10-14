 import {v4 as uuid} from 'uuid';
export interface IBasket {
  id: string;
  items:  IBasketItem[] ;
}
export interface IBasketItem  {
  id: number;
  productName: string;
  price: number;
  quantity: number;
  type: string;
  brand: string;
  pictureUrl: string;
}
export class Basket  implements IBasket
{
items: IBasketItem[]=[];
id=uuid();

}


export interface IBasketTotal {

  shipping: number;
  subTotal: number;
  total: number;

}
