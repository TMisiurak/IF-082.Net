import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
 
import { HomeComponent} from './components/home/home.component';
import { LoginComponent} from './components/login/login.component';
import { RegisterComponent} from './components/register/register.component';

import { GuestRoutingModule } from './guest-routing.module';
 
@NgModule({
  imports: [
    CommonModule,
    GuestRoutingModule
  ],
  declarations: [HomeComponent, LoginComponent, RegisterComponent,],
  providers: []
})
export class GuestModule { }