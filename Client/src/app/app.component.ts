import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'BID Sport Stuff Internet Shop';

  constructor(private basketService: BasketService) {
    const basketId = localStorage.getItem('basket_id');
    console.log(basketId);
    if (basketId)
    {
      this.basketService.getBasket(basketId)
        .subscribe(
          () => console.log('initialized basked'),
          console.error
        );
    }
  }

  ngOnInit(): void { }
}
