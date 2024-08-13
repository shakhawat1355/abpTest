import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomerDto, CustomerService } from '@proxy/customers';
import { Router } from '@angular/router';
import { CountryLookupDto, CountryService } from '@proxy/countries';
import { StateProvinceLookupDto, StateProvinceService } from '@proxy/state-provinces';
import { ValueDto } from '@proxy/values';
import { ToasterService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-customer-create',
  styleUrl: './customer-create.component.scss',
  templateUrl: './customer-create.component.html',
})
export class CustomerCreateComponent implements OnInit {
  form: FormGroup;
  selectedCustomer = {} as CustomerDto;
  pStatusList: ValueDto[];
  countries$: CountryLookupDto[];
  stateProvinces$: StateProvinceLookupDto[];
  filteredStateProvinces: StateProvinceLookupDto[];
  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private router: Router,
    private countryService: CountryService,
    private stateProvinceService: StateProvinceService,
    private toaster: ToasterService
  ) {
    countryService.getCountryLookup().subscribe(res => this.countries$ = res.items);
    stateProvinceService.getStateProvinceLookup().subscribe(res => this.stateProvinces$ = this.filteredStateProvinces = res.items);
    customerService.getCustomerDtoValues().subscribe(res => {
      this.selectedCustomer = res;
      this.pStatusList = res.availableStatuses;
      this.buildForm(this.selectedCustomer);
    });
  }

  ngOnInit(): void {

  }

  private buildForm(customer: CustomerDto) {
    debugger;
    this.form = this.fb.group({
      name: [customer.name || null, Validators.required],
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
    if (this.form.invalid) {
      return;
    }
    this.customerService.create(this.form.value).subscribe(() => {
      this.toaster.success('::CustomerUpdateSuccess');
      this.router.navigate(['/customers']);
    });
  }
}