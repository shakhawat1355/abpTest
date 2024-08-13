import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValueTypeSettingsComponent } from './value-type-settings.component';

describe('ValueTypeSettingsComponent', () => {
  let component: ValueTypeSettingsComponent;
  let fixture: ComponentFixture<ValueTypeSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ValueTypeSettingsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ValueTypeSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
