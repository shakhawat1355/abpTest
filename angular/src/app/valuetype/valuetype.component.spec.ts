import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValuetypeComponent } from './valuetype.component';

describe('ValuetypeComponent', () => {
  let component: ValuetypeComponent;
  let fixture: ComponentFixture<ValuetypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ValuetypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ValuetypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
