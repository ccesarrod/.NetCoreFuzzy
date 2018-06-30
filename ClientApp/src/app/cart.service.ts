import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs/Subject';
import { Product } from './product/product.component';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CartService {
  constructor(private httpclient: HttpClient) {
    this.itemsInCartSubject.subscribe(p => this.itemsInCart = p);
  }
  private itemsInCartSubject: Subject<Product[]> = new Subject();
  private itemsInCart: Product[] = [];

  addProduct(item: Product) {
    this.itemsInCartSubject.next([...this.itemsInCart, item]);
  
  }

  public getItems(): Observable<Product[]> {
    return this.itemsInCartSubject;
  }

 

}
