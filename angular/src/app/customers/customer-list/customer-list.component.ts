import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CustomerService, CustomerDto, CreateUpdateCustomerDto,ImportCustomerDto } from '@proxy/customers';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { EXPORT_CONFIG } from 'src/app/export/export-config';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  providers: [ListService],
})
export class CustomerListComponent implements OnInit {
  customers = { items: [], totalCount: 0 } as PagedResultDto<CustomerDto>;
  columns: string[] = ["actions", "id", "name", "type", "address1", "city", "zip", "creationTime"];
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

  constructor(
    public readonly list: ListService,
    private customerService: CustomerService,
    private confirmation: ConfirmationService,
    public router: Router
  ) {}

  ngOnInit(): void {
    const valueTypeStreamCreator = (query) => this.customerService.getList(query);
    this.list.hookToQuery(valueTypeStreamCreator).subscribe((response) => {
      this.customers = response;
      console.log(this.customers);
    });
    this.batchCustomerCreation();
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.customerService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  changePage(pageEvent: PageEvent) { 
    this.list.page = pageEvent.pageIndex;
   }

  changeSort(sort: Sort) {
    this.list.sortKey = sort.active;
    this.list.sortOrder = sort.direction;
  }

  batchCustomerCreation() {
    const data: ImportCustomerDto[] =[
      {
          name: "John Doe",
          address1: "123 Main St",
          address2: "Apt 4B",
          city: "Springfield",
          zip: "12345",
          stateProvince: "IL",
          country: "USA",
          isWholeSale: false,
          isOptDirectoryMarketing: true,
          statusValue: "Active",
          acctClassValue: "Standard",
          acctManagerValue: "Jane Smith",
          fax: "555-1234",
          taxExempt: false,
          discount: 10,
          invoicePaymentSchedulerValue: "Monthly",
          arStatementInvoiceTypeValue: "Email",
          referredByValue: "Referral",
          type: "Retail",
          store: "Main Store",
          discountOnWireout: 5,
          termValue: "Net 30",
          priceSheetCodeValue: "PS001",
          customerReference: "REF001",
          comment: "Preferred customer",
          creationTime: "2024-08-12T12:34:56Z"
      },
      {
          name: "Jane Roe",
          address1: "456 Oak St",
          address2: "Suite 200",
          city: "Metropolis",
          zip: "67890",
          stateProvince: "NY",
          country: "USA",
          isWholeSale: true,
          isOptDirectoryMarketing: false,
          statusValue: "Pending",
          acctClassValue: "Premium",
          acctManagerValue: "John Smith",
          fax: "555-5678",
          taxExempt: true,
          discount: 15,
          invoicePaymentSchedulerValue: "Quarterly",
          arStatementInvoiceTypeValue: "Paper",
          referredByValue: "Ad Campaign",
          type: "Wholesale",
          store: "Branch Store",
          discountOnWireout: 10,
          termValue: "Net 60",
          priceSheetCodeValue: "PS002",
          customerReference: "REF002",
          comment: "New client",
          creationTime: "2024-08-11T09:12:34Z"
      },
      {
          name: "Alex Smith",
          address1: "789 Pine St",
          address2: "",
          city: "Gotham",
          zip: "54321",
          stateProvince: "CA",
          country: "USA",
          isWholeSale: false,
          isOptDirectoryMarketing: true,
          statusValue: "Inactive",
          acctClassValue: "Basic",
          acctManagerValue: "Jane Doe",
          fax: "555-9876",
          taxExempt: false,
          discount: 5,
          invoicePaymentSchedulerValue: "Annually",
          arStatementInvoiceTypeValue: "Email",
          referredByValue: "Online Search",
          type: "Retail",
          store: "Online Store",
          discountOnWireout: 3,
          termValue: "Net 15",
          priceSheetCodeValue: "PS003",
          customerReference: "REF003",
          comment: "Occasional buyer",
          creationTime: "2024-08-10T14:23:45Z"
      }
  ];
    
    
  
    this.customerService.batchCustomerImport(data).subscribe({
      next: (response: string) => {
        console.log('Batch customer import successful:', response);
      },
      error: (error) => {
        console.error('Batch customer import failed:', error);
      }
    });
  }
  
  

}