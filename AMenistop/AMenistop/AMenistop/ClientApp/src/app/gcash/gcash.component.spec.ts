import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GcashComponent } from './gcash.component';

describe('GcashComponent', () => {
  let component: GcashComponent;
  let fixture: ComponentFixture<GcashComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GcashComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GcashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
