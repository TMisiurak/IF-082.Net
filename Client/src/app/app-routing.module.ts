import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NotFoundComponent } from './core/components/info-pages/errors/not-found/not-found.component';
import { LoginGuard } from './_guards/login.guard';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '', loadChildren: './guest/guest.module#GuestModule' },
    { path: 'patient', loadChildren: './patient/patient.module#PatientModule', canActivate: [LoginGuard] },
    { path: 'registry', loadChildren: './registry/registry.module#RegistryModule', canActivate: [LoginGuard] },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(appRoutes, { enableTracing: true } ) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}