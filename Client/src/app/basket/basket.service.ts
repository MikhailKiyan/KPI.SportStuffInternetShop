import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBasketTotals } from '../shared/models/basketTotals';
import { CustomerBasket, ICustomerBasket } from '../shared/models/customerBasket';
import { ICustomerBasketItem } from '../shared/models/customerBasketItem';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<ICustomerBasket | null>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalsSource = new BehaviorSubject<IBasketTotals | null>(null);
  basketTotals$ = this.basketTotalsSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get<ICustomerBasket>(this.baseUrl + 'baskets/' + id)
      .pipe(
        map((basket: ICustomerBasket) => {
          this.basketSource.next(basket);
          this.calculateBasketTotals();
        })
      );
  }

  setBasket(basket: ICustomerBasket) {
    return this.http.post<ICustomerBasket>(this.baseUrl + 'baskets', basket)
      .subscribe(
        (response: ICustomerBasket) => {
          this.basketSource.next(response);
          this.calculateBasketTotals();
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

  incrementItemQuantity(item: ICustomerBasketItem) {
    const basket:ICustomerBasket = this.getCurrentBasketValue() as ICustomerBasket;
    const itemIndex = basket.items.findIndex(x => x.id === item.id);
    basket.items[itemIndex].quantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item: ICustomerBasketItem) {
    const basket:ICustomerBasket = this.getCurrentBasketValue() as ICustomerBasket;
    const itemIndex = basket.items.findIndex(x => x.id === item.id);
    if (basket.items[itemIndex].quantity > 1) {
      basket.items[itemIndex].quantity--;
      this.setBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: ICustomerBasketItem) {
    const basket:ICustomerBasket = this.getCurrentBasketValue() as ICustomerBasket;
    if (basket.items.some(x => x.id === item.id)) {
      basket.items = basket.items.filter(i => i.id !== item.id);
      if (basket.items.length > 0)
      {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }

  deleteBasket(basket: ICustomerBasket) {
    return this.http.delete(this.baseUrl + 'baskets/' + basket.id)
      .subscribe(() => {
        this.basketSource.next(null);
        this.basketTotalsSource.next(null);
        localStorage.removeItem('basket_id');
      }, console.error);
  }

  private mapProductItemToBasketItem(
      item: IProduct,
      quantity: number
    ): ICustomerBasketItem {
    return {
      id: item.id,
      productName: item.name,
      pictureUrl: item.pictureUrl,
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

  private calculateBasketTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket?.items.reduce((accum, item) => (item.price * item.quantity) + accum, 0) ?? 0;
    const total = subtotal + shipping;
    const basketTotals: IBasketTotals = {
      shipping,
      subtotal,
      total
    };
    this.basketTotalsSource.next(basketTotals);
  }
}
