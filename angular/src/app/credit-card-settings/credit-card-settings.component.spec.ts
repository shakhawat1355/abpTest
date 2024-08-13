import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditCardSettingsComponent } from './credit-card-settings.component';

describe('CreditCardSettingsComponent', () => {
  let component: CreditCardSettingsComponent;
  let fixture: ComponentFixture<CreditCardSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreditCardSettingsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreditCardSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
