import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../product/product.component';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable()
export class CartService {
  private itemsInCartSubject: BehaviorSubject<Product[]> = new BehaviorSubject([]);
  private itemsInCart: Product[] = [];

  constructor(private httpclient: HttpClient) {

    this.itemsInCartSubject.subscribe(p => this.itemsInCart = p);
  }


  addProduct(item: Product) {
    this.itemsInCartSubject.next([...this.itemsInCart, item]);

  }

  getCart(): Subject<Product[]> {

    if (this.itemsInCartSubject != null)
      this.itemsInCartSubject.next(this.itemsInCart);

    return this.itemsInCartSubject;
  }


}
