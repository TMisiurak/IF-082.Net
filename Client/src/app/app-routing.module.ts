import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NotFoundComponent } from './shared/components/info-pages/errors/not-found/not-found.component';
import { LoginGuard } from './core/guards/login.guard';
import { ContactsComponent } from './shared/components/info-pages/contacts/contacts.component';
import { AboutComponent } from './shared/components/info-pages/about/about.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'guest', pathMatch: 'full' },
    { path: '', loadChildren: './guest/guest.module#GuestModule' },
    { path: 'patient', loadChildren: './patient/patient.module#PatientModule', canActivate: [LoginGuard] },
    { path: 'registry', loadChildren: './registry/registry.module#RegistryModule', canActivate: [LoginGuard] },
    { path: 'contacts', component: ContactsComponent },
    { path: 'about', component: AboutComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(appRoutes, { enableTracing: true } ) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
