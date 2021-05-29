import { v4 as uuidv4 } from 'uuid'
import { ICustomerBasketItem } from "./CustomerBasketItem";

export interface ICustomerBasket {
  id: string;
  items: ICustomerBasketItem[]
}

export class CustomerBasket implements ICustomerBasket {
  id = uuidv4();
  items: ICustomerBasketItem[] = [];
}
