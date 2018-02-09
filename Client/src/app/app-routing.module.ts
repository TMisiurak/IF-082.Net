import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegisterComponent } from './core/components/register/register.component';
import { LoginComponent } from './core/components/login/login.component';
import { NotFoundComponent } from './core/components/info-pages/errors/not-found/not-found.component';
import { LoginGuard } from './_guards/login.guard';

const appRoutes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'patient', loadChildren: './patient/patient.module#PatientModule', canActivate: [LoginGuard] },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(appRoutes, { enableTracing: true } ) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}