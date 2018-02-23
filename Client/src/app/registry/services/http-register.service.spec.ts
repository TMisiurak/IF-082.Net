import { TestBed, inject } from '@angular/core/testing';

import { HttpRegisterService } from './http-register.service';

describe('HttpRegisterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpRegisterService]
    });
  });

  it('should be created', inject([HttpRegisterService], (service: HttpRegisterService) => {
    expect(service).toBeTruthy();
  }));
});
