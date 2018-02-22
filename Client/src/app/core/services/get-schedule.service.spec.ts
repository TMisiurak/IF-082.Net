import { TestBed, inject } from '@angular/core/testing';

import { GetScheduleService } from './get-schedule.service';

describe('GetScheduleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GetScheduleService]
    });
  });

  it('should be created', inject([GetScheduleService], (service: GetScheduleService) => {
    expect(service).toBeTruthy();
  }));
});
