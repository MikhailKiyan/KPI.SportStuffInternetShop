import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICustomerBasket } from '../shared/models/customerBasket';
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

  ngOnInit(): void {
  }

}
