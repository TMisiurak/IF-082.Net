import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { guestSideNav } from '../../shared/helpers/menu/side-nav';

@Injectable()
export class AssignSideNavService {
  private menuSource = new BehaviorSubject<any>(guestSideNav);
  currentMenu = this.menuSource.asObservable();

  constructor() { }

  changeMenu(menu: any) {
    this.menuSource.next(menu);
  }

}
