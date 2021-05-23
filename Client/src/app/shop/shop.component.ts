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
  brandIdSelected = '';
  typeIdSelected = '';
  sortSelected = '';
  sortOptions = [
    { name: 'Alphabetical', value: '' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ]



  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getTypes();
    this.getBrands();
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe(
      response => this.products = response?.data ?? [],
      error => console.error(error));
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      response => this.brands = [{id: '', name: 'All'}, ...response],
      error => console.error(error));
  }

  getTypes() {
    this.shopService.getTypes().subscribe(
      response => this.types = [{id: '', name: 'All'}, ...response],
      error => console.error(error));
  }

  onBrandSelected(brandId: string) {
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: string) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.sortSelected = sort;
    this.getProducts();
  }
}
