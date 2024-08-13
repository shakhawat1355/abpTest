import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailDirectoryComponent } from './email-directory.component';

describe('EmailDirectoryComponent', () => {
  let component: EmailDirectoryComponent;
  let fixture: ComponentFixture<EmailDirectoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmailDirectoryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmailDirectoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
