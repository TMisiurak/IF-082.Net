import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
 
import { GuestComponent } from './guest.component';
import { HomeComponent} from './components/home/home.component';
import { LoginComponent} from './components/login/login.component';

import { HttpLoginService } from './services/http-login.service';

import { GuestRoutingModule } from './guest-routing.module';
import { CarouselComponent } from './components/carousel/carousel.component';
 
@NgModule({
  imports: [
    CommonModule, FormsModule, ReactiveFormsModule,
    SharedModule, 
    
    GuestRoutingModule
  ],
  declarations: [GuestComponent, HomeComponent, LoginComponent, CarouselComponent,],
  providers: [HttpLoginService]
})
export class GuestModule { }