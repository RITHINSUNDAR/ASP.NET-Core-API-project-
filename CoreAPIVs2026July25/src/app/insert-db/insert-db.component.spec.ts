import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertDBComponent } from './insert-db.component';

describe('InsertDBComponent', () => {
  let component: InsertDBComponent;
  let fixture: ComponentFixture<InsertDBComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsertDBComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsertDBComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
