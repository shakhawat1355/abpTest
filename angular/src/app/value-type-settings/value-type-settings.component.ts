import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToasterService } from '@abp/ng.theme.shared';
import { ValueTypeSettingService } from '@proxy/value-type-settings';
import { ValueTypeLookupDto, ValueTypeService } from '@proxy/values';


@Component({
  selector: 'app-value-type-settings',
  templateUrl: './value-type-settings.component.html',
  styleUrl: './value-type-settings.component.scss'
})
export class ValueTypeSettingsComponent implements OnInit{
  form:FormGroup;
  valueTypes$: ValueTypeLookupDto[];
  constructor(
    private valuetypeSettingService: ValueTypeSettingService,
    private valueTypeService: ValueTypeService,
    private fb: FormBuilder,
    private toaster: ToasterService
    )
  {
    valueTypeService.getValueTypeLookup().subscribe(res => this.valueTypes$ = res.items);
    this.buildFrom();
  }

  ngOnInit(): void {
    this.getValueTypeSetting();
  }

  getValueTypeSetting() {
    this.valuetypeSettingService.getValueTypeSetting().subscribe(valuetypeSetting => {
      this.form.patchValue(valuetypeSetting);
    })
  }

  buildFrom() {
    this.form = this.fb.group({
      tenantId: [''],
      customerSettings: this.fb.group({
        status: [null, Validators.required],
        type: [null, Validators.required],
        acctClass: [null, Validators.required],
        acctManager: [null, Validators.required],
        invoicePaymentSchedule: [null, Validators.required],
        term: [null, Validators.required],
        arStatementInvoiceType: [null, Validators.required],
        priceSheetCode: [null, Validators.required],
        referredBy: [null, Validators.required],
      }),
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const request= this.valuetypeSettingService.saveValueTypeSetting(this.form.value);
    request.subscribe({
      next: () => {
        this.getValueTypeSetting();
        this.toaster.success('::ValueTypeSettingSavedSuccessfully');
      },
      error: (err) => {
        this.toaster.error('::ValueTypeSettingSaveError');
      }
    });
  }
}
