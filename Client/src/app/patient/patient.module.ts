import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';

import { PatientComponent } from './patient.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';

import { PatientRoutingModule } from './patient-routing.module';

@NgModule({
	declarations: [ PatientComponent, HomeComponent, ProfileComponent, 
	],
	imports: [
		CommonModule, FormsModule, ReactiveFormsModule,
		SharedModule,
		
	    PatientRoutingModule
	],
	entryComponents: [
    	
  	],
	providers: [

	]
})

export class PatientModule { }