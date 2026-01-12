import { TestBed } from '@angular/core/testing';

import { ConServiceService } from './con-service.service';

describe('ConServiceService', () => {
  let service: ConServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
