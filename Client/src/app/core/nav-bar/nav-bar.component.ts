import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { ICustomerBasket } from 'src/app/shared/models/customerBasket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  basket$: Observable<ICustomerBasket | null>;

  constructor(private basketService: BasketService) {
    this.basket$ = this.basketService.basket$;
  }

  ngOnInit(): void { }
}
