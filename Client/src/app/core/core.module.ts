import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';
 
import { HeaderComponent} from './components/header/header.component';
import { FooterComponent} from './components/footer/footer.component';
import { TopNavComponent} from './components/navs/top-nav/top-nav.component';
import { NotFoundComponent} from './components/info-pages/errors/not-found/not-found.component';
import { FooterNavComponent } from './components/navs/footer-nav/footer-nav.component';

import { JwtDecoderService } from './_services/jwt-decoder.service';
import { GetUserService } from './_services/get-user.service';
import { CheckTokenService } from './_services/check-token.service';

import { throwIfAlreadyLoaded } from './module-import-guard';
 
@NgModule({
  imports: [
    CommonModule, RouterModule, FormsModule
  ],
  exports: [HeaderComponent, FooterComponent, TopNavComponent, NotFoundComponent, FooterNavComponent],
  declarations: [HeaderComponent, FooterComponent, TopNavComponent, NotFoundComponent, FooterNavComponent],
  providers: [JwtDecoderService, GetUserService, CheckTokenService]
})
export class CoreModule {
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}