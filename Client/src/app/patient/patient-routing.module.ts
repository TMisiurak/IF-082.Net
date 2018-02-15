import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PatientComponent } from './patient.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';

const childrenRoutes: Routes = [
    { path: '', redirectTo: '/patient/home', pathMatch: 'full' },
	{ path: 'home', component: HomeComponent },
	{ path: 'profile', component: ProfileComponent }
];
const patientRoutes: Routes = [
	{ path: '', component: PatientComponent, children: childrenRoutes }
];

@NgModule({
	imports: [ RouterModule.forChild(patientRoutes) ],
	exports: [ RouterModule ]
})

export class PatientRoutingModule { }