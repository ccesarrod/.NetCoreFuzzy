import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Observable } from 'rxjs/Observable';
import { Product } from '../product/product.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
 
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  shoppingCartItems$: Observable<Product[]>;
  private itemsInCart: number;

  constructor(private cartService: CartService) {}

  collapse() {
    this.isExpanded = false;
  }

  ngOnInit() {

    this.shoppingCartItems$ = this.cartService.getItems();

    this.shoppingCartItems$.subscribe(p => this.itemsInCart = p.length);

  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
