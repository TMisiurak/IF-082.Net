import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GuestComponent } from './guest.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { NotFoundComponent } from '../shared/components/info-pages/errors/not-found/not-found.component';

const childrenRoutes: Routes = [
	{ path: '', redirectTo: '/guest/home', pathMatch: 'full' },
	{ path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent },
	{ path: 'register', component: RegisterComponent },
	{ path: '**', component: NotFoundComponent }
];
const guestRoutes: Routes = [
	{ path: 'guest', component: GuestComponent, children: childrenRoutes }
];

@NgModule({
	imports: [ RouterModule.forChild(guestRoutes) ],
	exports: [ RouterModule ]
})

export class GuestRoutingModule { }