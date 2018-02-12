import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegistryComponent } from './registry.component';

const childrenRoutes: Routes = [
    //{ path: 'chat', component: MessageListComponent },
];
const registryRoutes: Routes = [
    { path: '', component: RegistryComponent },
	{ path: '', component: RegistryComponent, children: childrenRoutes }
];

@NgModule({
	imports: [ RouterModule.forChild(registryRoutes) ],
	exports: [ RouterModule ]
})

export class RegistryRoutingModule { }