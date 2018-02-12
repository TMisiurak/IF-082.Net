import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistryComponent } from './registry.component';

import { RegistryRoutingModule } from './registry-routing.module';

@NgModule({
  imports: [
    CommonModule,
    RegistryRoutingModule
  ],
  declarations: [RegistryComponent]
})
export class RegistryModule { }
