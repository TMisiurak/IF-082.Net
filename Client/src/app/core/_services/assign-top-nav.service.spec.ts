import { TestBed, inject } from '@angular/core/testing';

import { AssignTopNavService } from './assign-top-nav.service';

describe('AssignTopNavService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssignTopNavService]
    });
  });

  it('should be created', inject([AssignTopNavService], (service: AssignTopNavService) => {
    expect(service).toBeTruthy();
  }));
});
