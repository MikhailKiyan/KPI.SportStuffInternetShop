import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { CustomerBasket, ICustomerBasket } from '../shared/models/customerBasket';
import { ICustomerBasketItem } from '../shared/models/CustomerBasketItem';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<ICustomerBasket | null>(null);
  basket$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get<ICustomerBasket>(this.baseUrl + 'baskets/' + id)
      .pipe(
        map((basket: ICustomerBasket) => {
          this.basketSource.next(basket);
          console.log(this.getCurrentBasketValue());
        })
      );
  }

  setBasket(basket: ICustomerBasket) {
    return this.http.post<ICustomerBasket>(this.baseUrl + 'baskets', basket)
      .subscribe(
        (response: ICustomerBasket) => {
          console.log(response);
          this.basketSource.next(response);
        },
        (error: any) => console.error
      );
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(
      item: IProduct,
      quantity = 1
    ) {
    const itemToAdd: ICustomerBasketItem = this.mapProductItemToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }


  private mapProductItemToBasketItem(
      item: IProduct,
      quantity: number
    ): ICustomerBasketItem {
    return {
      id: item.id,
      productName: item.name,
      pictireUrl: item.pictureUrl,
      price: item.price,
      quantity,
      type: item.productType,
      brand: item.productBrand
    };
  }

  private createBasket(): ICustomerBasket {
    const basket = new CustomerBasket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private addOrUpdateItem(
      items: ICustomerBasketItem[],
      itemToAdd: ICustomerBasketItem,
      quantity: number
    ): ICustomerBasketItem[] {
    const index = items.findIndex(x => x.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }
}
