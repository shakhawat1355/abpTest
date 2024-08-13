import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { StoreService, TimeZone, timeZoneOptions } from '@proxy/stores';
import { CountryLookupDto, CountryService } from '@proxy/countries';
import { StateProvinceLookupDto, StateProvinceService } from '@proxy/state-provinces';
import { ValueTypeService, ValueTypeLookupDto } from '@proxy/values';

const { required } = Validators;

@Component({
  selector: 'app-store-create',
  templateUrl: './store-create.component.html',
  styleUrl: './store-create.component.scss',
  providers: [{ provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class StoreCreateComponent implements OnInit {
  form: FormGroup;
  valueTypes$: ValueTypeLookupDto[];
  countries$: CountryLookupDto[];
  stateProvinces$: StateProvinceLookupDto[];
  filteredStateProvinces: StateProvinceLookupDto[];
  timeZones = timeZoneOptions;

  constructor(
    private storeService: StoreService,
    private countryService: CountryService,
    private stateProvinceService: StateProvinceService,
    private valueTypeService: ValueTypeService,
    private fb: FormBuilder,
    private router: Router
  ) {
    valueTypeService.getValueTypeLookup().subscribe(res => this.valueTypes$ = res.items);
    countryService.getCountryLookup().subscribe(res => this.countries$ = res.items);
    stateProvinceService.getStateProvinceLookup().subscribe(res => this.stateProvinces$ = this.filteredStateProvinces = res.items);
    this.buildForm();
  }
  ngOnInit(): void {
  }

  private buildForm() {
    this.form = this.fb.group({
      storeName: [null, Validators.required],
      storeCode: [null, required],
      contactName: [null, required],
      email: [null, required],
      addressLine1: [null, required],
      addressLine2: [null],
      city: [null, required],
      zipCode: [null, required],
      countryId: [null, required],
      provinceId: [null, required],
      phone: [null, required],
      managerId: [null, required],
      timeZone: [TimeZone.EST, required],
      faxNumber: [null, required],
      isAddOnMasDirectory: [false],
      isPrimaryStore: [false],
      salesTax: [0.0,],
      isTrackInventory: [false],
      timeFormateId: [12],
      dateTimeFormate: ['MM/DD/YYYY', required],
      facebookUrl: [null],
      twitterUrl: [null],
      pinterestUrl: [null],
      addtoMasDirectoryNetwork: [false],
      receiptFooterNote: [null],
    });
  }

  onChangeCountry(event: any) {
    if (event) { 
      if (!event.value) {
        return;
      }

     this.filteredStateProvinces  = this.stateProvinces$.filter(item => item.countryId === event.value);
    }
    else {
      this.form.patchValue({
        stateProvinceId: null,
      })
      this.filteredStateProvinces = [];
    }
  }

  save() {
    if (this.form.invalid) return;

    this.storeService.create(this.form.value).subscribe(() => {
      this.router.navigate(['/stores']);
    });
  }
}