import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegistryComponent } from './registry.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';
import { NotFoundComponent } from '../shared/components/info-pages/errors/not-found/not-found.component';
import { AppointmentsComponent } from './components/appointment/appointment.component';

const childrenRoutes: Routes = [
    { path: '', redirectTo: '/registry/home', pathMatch: 'full' },
	{ path: 'home', component: HomeComponent },
	{ path: 'profile', component: ProfileComponent },
	{ path: 'appointment', component: AppointmentsComponent },
	{ path: '**', component: NotFoundComponent }
];
const registryRoutes: Routes = [
    { path: '', component: RegistryComponent, children: childrenRoutes }
];

@NgModule({
	imports: [ RouterModule.forChild(registryRoutes) ],
	exports: [ RouterModule ]
})

export class RegistryRoutingModule { }