import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import {  StoreDto, StoreService, timeZoneOptions } from '@proxy/stores';
import { CountryLookupDto, CountryService } from '@proxy/countries';
import { StateProvinceLookupDto, StateProvinceService } from '@proxy/state-provinces';
import {  ValueTypeLookupDto, ValueTypeService } from '@proxy/values';
import { filter, switchMap, tap } from 'rxjs';
import { StoreWorkHourLookupDto } from '@proxy/store-work-hours';

const { required } = Validators;

@Component({
  selector: 'app-store-edit',
  templateUrl: './store-edit.component.html',
  styleUrl: './store-edit.component.scss',
  providers: [{ provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class StoreEditComponent implements OnInit {
  form: FormGroup;
  valueTypes$: ValueTypeLookupDto[];
  countries$: CountryLookupDto[];
  stateProvinces$: StateProvinceLookupDto[];
  filteredStateProvinces: StateProvinceLookupDto[];
  timeZones = timeZoneOptions;
  id: string;
  selectedCountry: string;
  selectedFile: File;
  imageUrl: string;
  hasImage: boolean = false;

  constructor(
    private storeService: StoreService,
    private countryService: CountryService,
    private stateProvinceService: StateProvinceService,
    private valueTypeService: ValueTypeService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    valueTypeService.getValueTypeLookup().subscribe(res =>
      this.valueTypes$ = res.items
    );
    countryService.getCountryLookup().subscribe(res =>
      this.countries$ = res.items
    );
    stateProvinceService.getStateProvinceLookup().subscribe(res => {
      this.stateProvinces$ = res.items;
      this.filteredStateProvinces = this.stateProvinces$.filter(item => item.countryId === this.selectedCountry);
    });
    this.activatedRoute.params
      .pipe(
        filter(params => params.id),
        tap(({ id }) => (this.id = id)),
        switchMap(({ id }) => this.storeService.get(id)),
        tap(store => this.buildForm(store)
        )
      )
      .subscribe();
  }
  ngOnInit(): void {
  }

  private buildForm(store: StoreDto) {
    console.log(store);
    this.form = this.fb.group({
      storeName: [store.storeName, required],
      tenantId: [store.tenantId || ''], 
      storeCode: [store.storeCode, required],
      contactName: [store.contactName, required],
      email: [store.email, required],
      addressLine1: [store.addressLine1, required],
      addressLine2: [store.addressLine2],
      city: [store.city, required],
      zipCode: [store.zipCode, required],
      countryId: [store.countryId, required],
      provinceId: [store.provinceId, required],
      phone: [store.phone, required],
      managerId: [store.managerId, required],
      timeZone: [store.timeZone, required],
      faxNumber: [store.faxNumber, required],
      isAddOnMasDirectory: [store.isAddOnMasDirectory],
      isPrimaryStore: [store.isPrimaryStore],
      salesTax: [store.salesTax,],
      isTrackInventory: [store.isTrackInventory],
      timeFormateId: [store.timeFormateId],
      dateTimeFormate: [store.dateTimeFormate, required],
      facebookUrl: [store.facebookUrl],
      twitterUrl: [store.twitterUrl],
      pinterestUrl: [store.pinterestUrl],
      addtoMasDirectoryNetwork: [store.addtoMasDirectoryNetwork],
      receiptFooterNote: [store.receiptFooterNote],
      storeWorkHours: this.fb.array([])
    });
    this.selectedCountry = store.countryId;
    this.loadFile(this.id);
    this.setStoreWorkHours(store.storeWorkHours);
  }

  setStoreWorkHours(workHours: StoreWorkHourLookupDto[]) {
    const workHoursFGs = workHours.map(workHour => this.fb.group(workHour));
    const workHoursFormArray = this.fb.array(workHoursFGs);
    this.form.setControl('storeWorkHours', workHoursFormArray);
  }

  onChangeCountry(event: any) {
    if (event) {
      if (!event.value) {
        return;
      }

      this.filteredStateProvinces = this.stateProvinces$.filter(item => item.countryId === event.value);
    }
    else {
      this.form.patchValue({
        stateProvinceId: null,
      })
      this.filteredStateProvinces = [];
    }
  }

  save() {
    if (this.form.invalid) 
      return;

    this.storeService.update(this.id, this.form.value).subscribe(() => {
      this.router.navigate(['/stores']);
    });
  }

  onFileChange(event) {
    if (event.target.files.length > 0) {
      this.selectedFile = event.target.files[0];

      const myFormData = new FormData();
      myFormData.append('file', this.selectedFile); // file must match variable name in AppService
      this.storeService.uploadLogoByFileAndId(myFormData, this.id).subscribe(() =>{
        this.loadFile(this.id);
      })
    }
  }

  loadFile(id: string) {
    this.storeService.getLogoById(id).subscribe((blob) => {
      if (blob.size > 0) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.imageUrl = e.target.result;
          this.hasImage = true;
        };
        reader.readAsDataURL(blob);
      } else {
        this.hasImage = false;
      }
    });
  }
}