import { map } from 'rxjs/operators';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getProducts(brandId?: string | null, typeId?: string | null) {
    let params = new HttpParams();
    if (brandId) params = params.append('brandId', brandId);
    if (typeId) params = params.append('typeId', typeId);
    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
      .pipe(
        map(response => response.body)
      );
  }

  getBrands() {
    return this.http.get<IProductBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'products/types');
  }
}
