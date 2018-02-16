import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';

import { HeaderComponent} from './components/header/header.component';
import { FooterComponent} from './components/footer/footer.component';
import { TopNavComponent} from './components/navs/top-nav/top-nav.component';
import { NotFoundComponent} from './components/info-pages/errors/not-found/not-found.component';
import { FooterNavComponent } from './components/navs/footer-nav/footer-nav.component';

@NgModule({
  imports: [
    CommonModule, RouterModule, FormsModule
  ],
  declarations: [HeaderComponent, FooterComponent, TopNavComponent, NotFoundComponent, FooterNavComponent],
  exports: [HeaderComponent, FooterComponent, TopNavComponent, NotFoundComponent, FooterNavComponent],
})
export class SharedModule { }
