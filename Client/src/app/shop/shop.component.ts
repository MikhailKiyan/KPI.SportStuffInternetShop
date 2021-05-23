import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
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
  shopParams = new ShopParams();
  totalCount = 0;
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
    this.shopService.getProducts(this.shopParams).subscribe(
      response => {
        this.products = response?.data ?? [];
        this.shopParams.pageNumber = response?.pageIndex ?? 1;
        this.shopParams.pageSize = response?.pageSize ?? 6;
        this.totalCount = response?.count ?? 0;
      },
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
    this.shopParams.brandId = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: string) {
    this.shopParams.typeId = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChange(page: number) {
    this.shopParams.pageNumber = page;
    this.getProducts();
  }
}
