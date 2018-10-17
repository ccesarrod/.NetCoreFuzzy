import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { Observable } from 'rxjs/Observable';
import { Product } from '../product/product.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
 
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  shoppingCartItems$: Observable<Product[]>;


  constructor(private cartService: CartService) {}

  collapse() {
    this.isExpanded = false;
  }

  ngOnInit() {

    this.shoppingCartItems$ = this.cartService.getCart();

    this.shoppingCartItems$.subscribe(p => p);

  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
