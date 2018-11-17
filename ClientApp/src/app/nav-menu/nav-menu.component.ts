import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { Observable } from 'rxjs/Observable';
import { Product } from '../product/product.component';
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
 
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  shoppingCartItems$: Observable<Product[]>;
  userName: string = "";
  loginAction: string = "Login";
  isLogin: boolean = false;

  constructor(private cartService: CartService, private authenticationService: AuthenticationService, private router:Router) {}

  collapse() {
    this.isExpanded = false;
  }

  ngOnInit() {

    this.shoppingCartItems$ = this.cartService.getCart();
    this.shoppingCartItems$.subscribe(p => p);
    this.authenticationService.authenticatedUser.subscribe(currentUser =>
    {
      if (currentUser.user) {
        const user = currentUser.user;
        this.userName = user.userName;
        this.isLogin = true;
        this.loginAction = 'Log out'
      }
    },
      err => {
        console.log(err);
      });
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  login() {
    if (this.isLogin) {
      localStorage.removeItem('currentUser');
      this.isLogin = false;
      this.loginAction = 'Login';

    }
    else {
      this.router.navigate(['login']);
    }
  }
  
}
