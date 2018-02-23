import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PatientComponent } from './patient.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';
import { NotFoundComponent } from '../shared/components/info-pages/errors/not-found/not-found.component';
import { ContactsComponent } from '../shared/components/info-pages/contacts/contacts.component';
import { AboutComponent } from '../shared/components/info-pages/about/about.component';

const childrenRoutes: Routes = [
    { path: '', redirectTo: '/patient/home', pathMatch: 'full' },
	{ path: 'home', component: HomeComponent },
	{ path: 'profile', component: ProfileComponent },
	{ path: 'contacts', component: ContactsComponent },
    { path: 'about', component: AboutComponent },
	{ path: '**', component: NotFoundComponent }
];
const patientRoutes: Routes = [
	{ path: '', component: PatientComponent, children: childrenRoutes }
];

@NgModule({
	imports: [ RouterModule.forChild(patientRoutes) ],
	exports: [ RouterModule ]
})

export class PatientRoutingModule { }