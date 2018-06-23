import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from './product.component';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProductService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getProducts() : Observable<Product[]> {
     return this.http.get<Product[]>(this.baseUrl + 'api/Product/GetProducts');
  }

  getProductsByCategoryId(categoryId: string): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'api/Category/GetProductsByCategoryId/'+categoryId)
  }
}
