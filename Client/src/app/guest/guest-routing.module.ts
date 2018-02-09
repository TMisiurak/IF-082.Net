import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

const childrenRoutes: Routes = [
    //{ path: 'chat', component: MessageListComponent },
];
const guestRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent },
	{ path: 'register', component: RegisterComponent },
	/* { path: '', component: RegisterComponent, children: childrenRoutes } */
];

@NgModule({
	imports: [ RouterModule.forChild(guestRoutes) ],
	exports: [ RouterModule ]
})

export class GuestRoutingModule { }