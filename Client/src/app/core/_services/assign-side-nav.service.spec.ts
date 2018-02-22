import { TestBed, inject } from '@angular/core/testing';

import { AssignSideNavService } from './assign-side-nav.service';

describe('AssignSideNavService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssignSideNavService]
    });
  });

  it('should be created', inject([AssignSideNavService], (service: AssignSideNavService) => {
    expect(service).toBeTruthy();
  }));
});
