import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { guestTopNav } from '../../shared/_shared/menu/top-nav';

@Injectable()
export class AssignTopNavService {
  private menuSource = new BehaviorSubject<any>(guestTopNav);
  currentMenu = this.menuSource.asObservable();

  constructor() { }

  changeMenu(menu: any) {
    this.menuSource.next(menu);
  }
}
