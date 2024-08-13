import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CorporateSettingService } from '@proxy/corporate-settings';
import { ToasterService } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-corporate-settings',
  templateUrl: './corporate-settings.component.html',
  styleUrl: './corporate-settings.component.scss'
})
export class CorporateSettingsComponent implements OnInit{
  form:FormGroup;

  constructor(
    private corporateSettingService: CorporateSettingService,
    private fb: FormBuilder,
    private toaster: ToasterService
    )
  {
    this.buildFrom();
  }

  ngOnInit(): void {
    this.getCorporateSetting();
  }

  getCorporateSetting() {
    this.corporateSettingService.getCorporateSetting().subscribe(corporateSetting => {
      this.form.patchValue(corporateSetting);
    })
  }

  buildFrom() {
    this.form = this.fb.group({
      tenantId: [''],
      wireOutOrderHoldTime: [0, Validators.required],
      printRawCommMessage: [false],
      geocodingPreferenceType: [0],
      updateQuantityCommittedDays: [0],
      passwordResetDays: [0],
      returnWindowDays: [0],
      allowCOD: [false],
      allowCashOrderEdits: [false],
      startingCustomerId: [0],
      startingOrderId: [0],
      printNoteCardType: [0],
      returnedCheckFee: [0],
      creditStatusNotAllowedToCharge: [0],
      fulfillingStoreId: [0],
      inventoryTrackingType: [0],
      applyCreditCardSetupToAllStores: [false],
      relayFee: [0],
      overseasRelayFee: [0],
      wireOutDeliveryFee: [0],
      taxOnDelivery: [false],
      taxOnRelay: [false],
      salesTaxPercentage: [0],
      funeralRequired: [false],
      hospitalRequired: [false],
      printFuneralReviewCopy: [false],
      printHospitalReviewCopy: [false],
      customerAccountInfoUpdateType: [0],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const request= this.corporateSettingService.saveCorporateSetting(this.form.value);
    request.subscribe({
      next: () => {
        this.getCorporateSetting();
        this.toaster.success('::CorporateSettingSavedSuccessfully');
      },
      error: (err) => {
        this.toaster.error('::CorporateSettingSaveError');
      }
    });
  }
}
