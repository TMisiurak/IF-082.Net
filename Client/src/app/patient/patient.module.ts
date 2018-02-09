import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule }   from '@angular/http';

import { PatientComponent } from './patient.component';

import { PatientRoutingModule } from './patient-routing.module';

@NgModule({
	declarations: [ PatientComponent, 
	],
	imports: [
		CommonModule, FormsModule, ReactiveFormsModule, HttpModule,
	    PatientRoutingModule
	],
	entryComponents: [
    	
  	],
	providers: [

	]
})

export class PatientModule { }