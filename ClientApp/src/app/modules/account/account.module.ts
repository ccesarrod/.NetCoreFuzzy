import { NgModule } from "@angular/core";

import { LoginRoutingModule } from "@modules/account/account-routing.module";
import { LoginComponent } from '@modules/account/login/login.component';
import { RegisterComponent } from '@modules/account/register/register.component';

@NgModule({
  imports: [LoginRoutingModule],
  declarations: [LoginComponent, RegisterComponent]
})
export class AccountModule { }
