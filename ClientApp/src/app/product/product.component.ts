import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductService } from './product.service';

@Component({
  selector: 'app-products',
  templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
  public products: Product[];

  constructor(private service: ProductService) {
   
  }

  ngOnInit(): void {

    this.service.getProducts().subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}

export interface Product {
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
