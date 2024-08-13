import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporateSettingsComponent } from './corporate-settings.component';

describe('CorporateSettingsComponent', () => {
  let component: CorporateSettingsComponent;
  let fixture: ComponentFixture<CorporateSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CorporateSettingsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CorporateSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
