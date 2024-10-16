import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SucessComponent } from './sucess.component';

describe('SucessComponent', () => {
  let component: SucessComponent;
  let fixture: ComponentFixture<SucessComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SucessComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SucessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
