import { Component, OnInit } from '@angular/core';
import { of, Observable } from 'rxjs';
import { CartService } from '../services/cart.service';
import { Product } from '../product/product.component';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  public shoppingCartItems$: Observable<Product[]> = of([]);
  public shoppingCartItems: Product[] = [];

  constructor(private cartService: CartService) {}

  ngOnInit() {

    this.shoppingCartItems$ = this.cartService.getCart();
    this.shoppingCartItems$.subscribe(cart => this.shoppingCartItems =cart);
  }

}
