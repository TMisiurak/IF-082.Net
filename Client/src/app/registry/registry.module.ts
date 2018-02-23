import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';

import { RegistryComponent } from './registry.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';

import { RegistryRoutingModule } from './registry-routing.module';
import { AppointmentService } from './services/appointment.service';
import { AppointmentsComponent } from './components/appointment/appointment.component';
import { RegisterComponent } from './components/register/register.component';
import { HttpRegisterService } from './services/http-register.service';

@NgModule({
  imports: [
    CommonModule, FormsModule, ReactiveFormsModule,
		SharedModule,
    
    RegistryRoutingModule
  ],
  declarations: [
    RegistryComponent, HomeComponent, ProfileComponent, AppointmentsComponent,
    RegisterComponent
  ],
  providers: [AppointmentService, HttpRegisterService]
})

export class RegistryModule { }
