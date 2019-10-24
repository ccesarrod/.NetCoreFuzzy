import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "@modules/home/home/home.component";
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AuthGuardService } from '@services/auth-guard.service';
import { CounterComponent } from './counter/counter.component';
import { CategoryComponent } from './category/category.component';
import { ProductComponent } from './product/product.component';
import { CategoryProductComponent } from './category-product/category-product.component';
import { CartComponent } from '@modules/account/cart/cart.component';


export const appRoutes: Routes = [
    {
      path: '',
      component: HomeComponent,
      pathMatch: 'full'             
    },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuardService]  },
    { path: 'fetch-products', component: ProductComponent },
    { path: 'fetch-categories', component: CategoryComponent  },
    { path: 'fetch-category-product/:id', component: CategoryProductComponent,  canActivate: [AuthGuardService] },
    { path: 'login', loadChildren: () => import('@modules/account/account.module').then(m => m.AccountModule) },
    {path: 'cart',  loadChildren: () => import('@modules/account/account.module').then(m => m.AccountModule)}
    
  ];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
