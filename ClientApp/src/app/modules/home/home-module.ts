import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HomeComponent} from './home/home.component'
import { NavMenuComponent } from './nav-menu/nav-menu.component';


@NgModule({
  declarations: [HomeComponent,NavMenuComponent],
  imports: [
    CommonModule
  ]
})
export class HomeModule { }
