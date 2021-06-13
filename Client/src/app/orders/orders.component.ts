import { Component, OnInit } from '@angular/core';
import { IOrder } from '../shared/models/order';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: IOrder[];

  constructor(private orderService: OrdersService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrdersForUser()
      .subscribe((orders: IOrder[]) => {
        this.orders = orders;
      }, error => {
        console.log(error);
      })
  }

  getStatusName(statusCode: string): string {
    switch(statusCode.toLowerCase()) {
      case "pending":
        return "Очикування оплати";

      case "paymentreceived":
        return "Оплата отримана";

      case "paymentfailed":
        return "Невдала оплата";

      default:
        return statusCode.toLowerCase();
    }
  }
}
