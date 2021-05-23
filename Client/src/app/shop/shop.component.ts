import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[] = [];
  brands: IProductBrand[] = [];
  types: IProductType[] = [];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getTypes();
    this.getBrands();
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts().subscribe(
      response => this.products = response.data,
      error => console.error(error));
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      response => this.brands = response,
      error => console.error(error));
  }

  getTypes() {
    this.shopService.getTypes().subscribe(
      response => this.types = response,
      error => console.error(error));
  }
}
