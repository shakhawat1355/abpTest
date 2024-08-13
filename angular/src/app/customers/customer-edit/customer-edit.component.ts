import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryLookupDto, CountryService } from '@proxy/countries';
import { StateProvinceLookupDto, StateProvinceService } from '@proxy/state-provinces';
import { ValueTypeLookupDto, ValueTypeService } from '@proxy/values';
import { filter, switchMap, tap } from 'rxjs';
import { CustomerDto, CustomerService } from '@proxy/customers';
import { ToasterService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrl: './customer-edit.component.scss',
})
export class CustomerEditComponent implements OnInit {
  form: FormGroup;
  valueTypes$: ValueTypeLookupDto[];
  countries$: CountryLookupDto[];
  stateProvinces$: StateProvinceLookupDto[];
  filteredStateProvinces: StateProvinceLookupDto[];
  id: string;
  selectedCountry: string;
  selectedCustomer = {} as CustomerDto;
  entityName = "Customer";

  constructor(
    private customerService: CustomerService,
    private countryService: CountryService,
    private stateProvinceService: StateProvinceService,
    private valueTypeService: ValueTypeService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toaster: ToasterService
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
    customerService.getCustomerDtoValues().subscribe(res => this.selectedCustomer = res);

    this.activatedRoute.params
      .pipe(
        filter(params => params.id),
        tap(({ id }) => (this.id = id)),
        switchMap(({ id }) => this.customerService.get(id)),
        tap(customer => this.buildForm(customer)
        )
      )
      .subscribe();
  }
  ngOnInit(): void {
  }

  private buildForm(customer: CustomerDto) {
    this.form = this.fb.group({
      name: [customer.name, Validators.required],
      tenantId: [customer.tenantId],
      address1: [customer.address1, Validators.required],
      address2: [customer.address2],
      countryId: [customer.countryId, Validators.required],
      stateProvinceId: [customer.stateProvinceId, Validators.required],
      city: [customer.city, Validators.required],
      zip: [customer.zip, Validators.required],
      fax: [customer.fax],
      isWholeSale: [customer.isWholeSale || false],
      isOptDirectoryMarketing: [customer.isOptDirectoryMarketing || false],
      statusValueId: [customer.statusValueId, Validators.required],
      typeId: [customer.typeId, Validators.required],
      acctClassValueId: [customer.acctClassValueId, Validators.required],
      acctManagerValueId: [customer.acctManagerValueId],
      storeId: [customer.storeId, Validators.required],
      taxExempt: [customer.taxExempt || false],
      discount: [customer.discount || 0],
      discountOnWireout: [customer.discountOnWireout || 0],
      invoicePaymentSchedulerValueId: [customer.invoicePaymentSchedulerValueId, Validators.required],
      termValueId: [customer.termValueId, Validators.required],
      arStatementInvoiceTypeValueId: [customer.arStatementInvoiceTypeValueId],
      priceSheetCodeValueId: [customer.priceSheetCodeValueId],
      referredByValueId: [customer.referredByValueId],
      customerReference: [customer.customerReference],
      comment: [customer.comment],
    });
    this.selectedCountry = customer.countryId;
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

    this.customerService.update(this.id, this.form.value).subscribe(() => {
      this.toaster.success('::CustomerUpdateSuccess');
      this.router.navigate(['/customers']);
    });
  }
}