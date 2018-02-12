import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
 
import { HomeComponent} from './components/home/home.component';
import { LoginComponent} from './components/login/login.component';
import { RegisterComponent} from './components/register/register.component';

import { HttpLoginService } from './_services/http-login.service';

import { GuestRoutingModule } from './guest-routing.module';
 
@NgModule({
  imports: [
    CommonModule, FormsModule, ReactiveFormsModule, GuestRoutingModule
  ],
  declarations: [HomeComponent, LoginComponent, RegisterComponent,],
  providers: [HttpLoginService]
})
export class GuestModule { }