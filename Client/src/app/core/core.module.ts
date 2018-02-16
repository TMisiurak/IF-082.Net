import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';
 
import { JwtDecoderService } from './_services/jwt-decoder.service';
import { GetUserService } from './_services/get-user.service';
import { CheckTokenService } from './_services/check-token.service';
import { AssignTopNavService } from './_services/assign-top-nav.service';

import { throwIfAlreadyLoaded } from './module-import-guard';
 
@NgModule({
  imports: [
    CommonModule, RouterModule, FormsModule
  ],
  declarations: [],
  exports: [],
  providers: [JwtDecoderService, GetUserService, CheckTokenService, AssignTopNavService]
})
export class CoreModule {
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}