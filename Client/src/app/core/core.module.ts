import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';
 
import { JwtDecoderService } from './services/jwt-decoder.service';
import { GetUserService } from './services/get-user.service';
import { CheckTokenService } from './services/check-token.service';
import { AssignTopNavService } from './services/assign-top-nav.service';
import { AssignSideNavService } from './services/assign-side-nav.service';
import { GetScheduleService } from './services/get-schedule.service';

import { throwIfAlreadyLoaded } from './module-import-guard';
 
@NgModule({
  imports: [
    CommonModule, RouterModule, FormsModule
  ],
  declarations: [],
  exports: [],
  providers: [JwtDecoderService, GetUserService, CheckTokenService, AssignTopNavService, AssignSideNavService, GetScheduleService]
})
export class CoreModule {
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}