import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProductService } from '../product/product.service';
import { Product } from '../product/product.component';
import { CartService } from '../cart.service';

@Component({
  selector: 'app-category-product',
  templateUrl: './category-product.component.html',
  styleUrls: ['./category-product.component.css']
})
export class CategoryProductComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService) { }
  products: Product[];
  ngOnInit() {

    this.getProducts();
  }

  getProducts(){
    var id = this.route.snapshot.paramMap.get('id');
    this.productService.getProductsByCategoryId(id)
      .subscribe(result => {
        this.products = result;
      }, error => console.log(error));
  }

  addToCart(item: Product) {
    this.cartService.addProduct(item);
  }

}
