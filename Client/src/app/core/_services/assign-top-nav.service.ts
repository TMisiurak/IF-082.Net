import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class AssignTopNavService {
  private menuSource = new BehaviorSubject<any>(
    [
      [
        {link1: "guest", link2: "home", name: "Home"},
        {link1: "guest", link2: "guest1", name: "Guest1"},
        {link1: "guest", link2: "guest2", name: "Guest2"}
      ],
      [
        {link1: "guest", link2: "login", name: "Sign In"},
        {link1: "guest", link2: "register", name: "Sign Up"}
      ],
      [
        {profile: 0, name: 0}
      ]
    ]
  );
  currentMenu = this.menuSource.asObservable();

  constructor() { }

  changeMenu(menu: any) {
    this.menuSource.next(menu);
  }
}
