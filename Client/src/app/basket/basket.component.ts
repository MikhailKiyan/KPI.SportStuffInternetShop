import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICustomerBasket } from '../shared/models/customerBasket';
import { ICustomerBasketItem } from '../shared/models/customerBasketItem';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  basket$: Observable<ICustomerBasket | null>;

  constructor(private basketService: BasketService) {
    this.basket$ = basketService.basket$;
  }

  ngOnInit(): void { }

  removeBasketItem(item: ICustomerBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: ICustomerBasketItem) {
    this.basketService.incrementItemQuantity(item);
  }

  decrementItemQantity(item: ICustomerBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }
}
