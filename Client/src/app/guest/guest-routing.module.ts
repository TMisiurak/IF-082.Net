import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GuestComponent } from './guest.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from '../shared/components/info-pages/errors/not-found/not-found.component';
import { ContactsComponent } from '../shared/components/info-pages/contacts/contacts.component';
import { AboutComponent } from '../shared/components/info-pages/about/about.component';

const childrenRoutes: Routes = [
	{ path: '', redirectTo: '/guest/home', pathMatch: 'full' },
	{ path: 'home', component: HomeComponent },
	{ path: 'login', component: LoginComponent },
	{ path: 'contacts', component: ContactsComponent },
    { path: 'about', component: AboutComponent },
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