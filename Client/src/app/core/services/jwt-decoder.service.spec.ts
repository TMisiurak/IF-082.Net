import { TestBed, inject } from '@angular/core/testing';

import { JwtDecoderService } from './jwt-decoder.service';

describe('JwtDecoderService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JwtDecoderService]
    });
  });

  it('should be created', inject([JwtDecoderService], (service: JwtDecoderService) => {
    expect(service).toBeTruthy();
  }));
});
