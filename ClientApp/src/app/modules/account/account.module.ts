import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginRoutingModule } from "@modules/account/account-routing.module";
import { LoginComponent } from '@modules/account/login/login.component';
import { RegisterComponent } from '@modules/account/register/register.component';


@NgModule({
  imports: [LoginRoutingModule, FormsModule,
   
    ReactiveFormsModule],
  declarations: [LoginComponent, 
    RegisterComponent,
    ]
})
export class AccountModule { }
