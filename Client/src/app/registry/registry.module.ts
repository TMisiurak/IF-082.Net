import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';

import { RegistryComponent } from './registry.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';

import { RegistryRoutingModule } from './registry-routing.module';
import { AppointmentService } from './_services/appointment.service';
import { AppointmentsComponent } from './components/appointment/appointment.component';

@NgModule({
  imports: [
    CommonModule, FormsModule, ReactiveFormsModule,
		SharedModule,
    
    RegistryRoutingModule
  ],
  declarations: [
    RegistryComponent, HomeComponent, ProfileComponent, AppointmentsComponent
  ],
  providers: [AppointmentService]
})

export class RegistryModule { }
