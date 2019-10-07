import { Component, OnInit } from '@angular/core';
import { CartService } from '@services/cart.service';
import { ICartItem } from '@components/models/cartItem';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public cart:any;
  constructor(private cartService: CartService) { }

 

  ngOnInit() {
    debugger
    this.cartService.getCart().subscribe(data=> {
      this.cart = data;
    });
  }

  addQuantity(item: ICartItem) {
    this.cartService.addQuantity(item);
  }

  removeItem(item: ICartItem) {
    this.cartService.removeQuantity(item);
  }

  get totalCount() {

    return this.cartService.totalCount();    
  }


  get totalPrice() {
    return this.cartService.totalPrice();
  }

}
