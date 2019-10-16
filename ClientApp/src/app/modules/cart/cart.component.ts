import { Component, OnInit } from '@angular/core';
import { CartService } from '@services/cart.service';
import { ICartItem } from '@components/models/cartItem';
import { AuthenticationService } from '@services/authentication.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public cart:any;
  constructor(private cartService: CartService,private authService: AuthenticationService) { }

 

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

  saveCart() {
    this.cartService.save().subscribe(x => {

      this.authService.authenticatedUser.value.cart = this.cart;

    });
  }

  get totalCount() {

    return this.cartService.totalCount();    
  }


  get totalPrice() {
    return this.cartService.totalPrice();
  }

  

}
