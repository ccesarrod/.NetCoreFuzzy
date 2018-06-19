import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-products',
  templateUrl: './product.component.html'
})
export class ProductComponent {
  public products: Product[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'api/Product/GetProducts').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}

interface Product {
  productName: string;
  productId: number;
  categoryId?: number;
  quantityPerUnit: string;
  unitPrice?: number;
  unitsInStock?: number;
  unitsOnOrder?: number;
  reorderLevel?: number;
  discontinued: boolean;
  }
