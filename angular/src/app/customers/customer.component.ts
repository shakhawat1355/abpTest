import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CustomerService, CustomerDto, } from '@proxy/customers';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ValueTypeService } from '@proxy/values/value-type.service';
import { ValueDto, ValueTypeLookupDto } from '@proxy/values';
import { EXPORT_CONFIG } from '../export/export-config';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  providers: [ListService],
})
export class CustomerComponent implements OnInit {
  exportUrl = EXPORT_CONFIG.customerUrl;

  exportFieldList = ['name', 'address1', 'address2', 'city', 'zip',
    'stateProvince', 'country', 'isWholeSale',
    'isOptDirectoryMarketing', 'statusValue',
    'acctClassValue', 'acctManagerValue', 'fax', 'taxExempt',
    'discount', 'invoicePaymentSchedulerValue', 'arStatementInvoiceTypeValue',
    'referredByValue', 'type', 'store', 'discountOnWireout',
    'termValue', 'priceSheetCodeValue',
    'customerReference', 'comment', 'creationTime',
  ];

  customers = { items: [], totalCount: 0 } as PagedResultDto<CustomerDto>
  selectedCustomer = {} as CustomerDto;
  isModalOpen = false;
  form: FormGroup;
  pValueList$: Observable<ValueTypeLookupDto[]>;
  pStatusList: ValueDto[];
  constructor(
    public readonly list: ListService,
    private customerService: CustomerService,
    private valueTypeService: ValueTypeService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {
    this.pValueList$ = valueTypeService.getValueTypeLookup().pipe(map((r) => r.items));
    customerService.getCustomerDtoValues().subscribe(res => { this.selectedCustomer = res;
      this.pStatusList = res.availableStatuses;
      console.log(this.pStatusList);
    });

  }

  ngOnInit(): void {
    const valueTypeStreamCreator = (query) => this.customerService.getList(query);

    this.list.hookToQuery(valueTypeStreamCreator).subscribe((respones) => {
      this.customers = respones;
    });
  }

  buildFrom() {
    this.form = this.fb.group({
      name: [this.selectedCustomer.name || '', Validators.required],
      tenantId: [this.selectedCustomer.tenantId || ''],
      address1: [this.selectedCustomer.address1 || '', Validators.required],
      address2: [this.selectedCustomer.address2 || ''],
      countryId: [this.selectedCustomer.countryId || 0], 
      stateProvinceId: [this.selectedCustomer.stateProvinceId || 0], 
      city: [this.selectedCustomer.city || '', Validators.required],
      zip: [this.selectedCustomer.zip || '', Validators.required],
      fax: [this.selectedCustomer.fax || ''],
      isWholeSale: [this.selectedCustomer.isWholeSale || false],
      isOptDirectoryMarketing: [this.selectedCustomer.isOptDirectoryMarketing || false],
      statusValueId: [this.selectedCustomer.statusValueId || '', Validators.required],
      typeId: [this.selectedCustomer.typeId || '', Validators.required],
      acctClassValueId: [this.selectedCustomer.acctClassValueId || '', Validators.required],
      acctManagerValueId: [this.selectedCustomer.acctManagerValueId || ''],
      storeId: [this.selectedCustomer.storeId || '', Validators.required],
      taxExempt: [this.selectedCustomer.taxExempt || false],
      discount: [this.selectedCustomer.discount || 0],
      discountOnWireout: [this.selectedCustomer.discountOnWireout || 0],
      invoicePaymentSchedulerValueId: [this.selectedCustomer.invoicePaymentSchedulerValueId || '', Validators.required],
      termValueId: [this.selectedCustomer.termValueId || '', Validators.required],
      arStatementInvoiceTypeValueId: [this.selectedCustomer.arStatementInvoiceTypeValueId || ''],
      priceSheetCodeValueId: [this.selectedCustomer.priceSheetCodeValueId || ''],
      referredByValueId: [this.selectedCustomer.referredByValueId || ''],
      customerReference: [this.selectedCustomer.customerReference || ''],
      comment: [this.selectedCustomer.comment || ''],

    });
  }

  createCustomer() {
    this.buildFrom();
    this.isModalOpen = true;
  }

  editCustomer(id: string) {
    this.customerService.get(id).subscribe((valueType) => {
      this.selectedCustomer = valueType;
      this.buildFrom();
      this.isModalOpen = true;
    })
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedCustomer.id
      ? this.customerService.update(this.selectedCustomer.id, this.form.value)
      : this.customerService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.selectedCustomer = {} as CustomerDto;
      this.list.get();
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.customerService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}