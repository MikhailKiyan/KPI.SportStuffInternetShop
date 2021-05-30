import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
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
export class ShopComponent implements OnInit, OnDestroy {
  @ViewChild('search', { static: false } ) searchTerm: ElementRef | null = null;
  products: IProduct[] = [];
  brands: IProductBrand[] = [];
  types: IProductType[] = [];
  shopParams = new ShopParams();
  totalCount = 0;
  sortOptions = [
    { name: 'По назві', value: '' },
    { name: 'Ціна: від дорогих до дешевих', value: 'priceAsc' },
    { name: 'Ціна: від дешевих до дорогих', value: 'priceDesc' }
  ]

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getTypes();
    this.getBrands();
    this.getProducts();
  }

  ngOnDestroy(): void {

  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe(
      response => {
        this.products = response?.data ?? [];
        this.shopParams.pageNumber = response?.pageIndex ?? 1;
        this.shopParams.pageSize = response?.pageSize ?? 9;
        this.totalCount = response?.count ?? 0;
      },
      error => console.error(error)
    );
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      response => this.brands = [{id: '', name: 'Всі'}, ...response],
      error => console.error(error));
  }

  getTypes() {
    this.shopService.getTypes().subscribe(
      response => this.types = [{id: '', name: 'Всі'}, ...response],
      error => console.error(error));
  }

  onBrandSelected(brandId: string) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: string) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChange(page: number) {
    if (this.shopParams.pageNumber === page) return;
    this.shopParams.pageNumber = page;
    this.getProducts();
  }

  onSearch() {
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm!.nativeElement!.value = null;
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
