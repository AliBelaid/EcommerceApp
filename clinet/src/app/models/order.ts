import { IAddress } from './address';

export interface IOrderItem {
  productId: number;
  productName: string;
  pictureUrl: string;
  price: number;
  quantity: number;
}

export interface IOrder {
  id: number;
  buyerEmail: string;
  orderDate: Date;
  shipAddress: IAddress;
  delivaryMethod: string;
  shippingPrice: number;
  orderItems: IOrderItem[];
  subtotal: number;
  status: string;
  total: number;
}
export interface IOrderToCreate {

  basketId: string;
  deliveryMethodId: number;
  shipToAddress: IAddress;
}
