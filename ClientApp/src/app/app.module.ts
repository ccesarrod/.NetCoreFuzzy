import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './modules/home/nav-menu/nav-menu.component';
import { HomeComponent } from '@modules/home/home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProductComponent } from './product/product.component';
import { ProductService } from '@services/product.service';
import { CategoryComponent } from './category/category.component';
import { CategoryService } from '@services/category.service';
import { CategoryProductComponent } from './category-product/category-product.component';
import {CartService } from './services/cart.service';
import { AuthGuardService } from './services/auth-guard.service';
import { AccountModule } from "@modules/account/account.module";
import { CartComponent } from '@modules/account/cart/cart.component'
import { JwtInterceptor} from './services/jwtInterceptor';
import { HomeModule } from "@modules/home/home-module";
import { AppRoutingModule } from './app.routing';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductComponent,
    CategoryComponent,
    CategoryProductComponent,    
     CartComponent
  
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AccountModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [ProductService, CategoryService, CartService, AuthGuardService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
