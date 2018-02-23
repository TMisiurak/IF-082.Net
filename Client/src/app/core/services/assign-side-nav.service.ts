import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { guestTopNav } from '../../shared/helpers/menu/top-nav';

@Injectable()
export class AssignSideNavService {
  private menuSource = new BehaviorSubject<any>(guestTopNav);
  currentMenu = this.menuSource.asObservable();

  constructor() { }

  changeMenu(menu: any) {
    this.menuSource.next(menu);
  }

}