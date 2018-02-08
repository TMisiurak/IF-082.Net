import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PatientComponent } from './patient.component';

const childrenRoutes: Routes = [
    //{ path: 'chat', component: MessageListComponent },
];
const patientRoutes: Routes = [
    { path: '', component: PatientComponent },
	{ path: '', component: PatientComponent, children: childrenRoutes }
];

@NgModule({
	imports: [ RouterModule.forChild(patientRoutes) ],
	exports: [ RouterModule ]
})

export class PatientRoutingModule { }