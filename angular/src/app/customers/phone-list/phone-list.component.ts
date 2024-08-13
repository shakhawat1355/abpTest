import { Component, Input, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { PhoneDirectoryDto, PhoneDirectoryService } from '@proxy/phone-directories';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-phone-list',
  templateUrl: './phone-list.component.html',
  providers: [ListService],
})

export class PhoneListComponent implements OnInit {

  @Input() entityId: string;
  @Input() entityName: string;

  selectedPhone = {} as PhoneDirectoryDto;
  phoneDirectories = { items: [], totalCount: 0 } as PagedResultDto<PhoneDirectoryDto>;
  columns: string[] = ["actions", "phoneNumber", "isPrimary", "isAcceptTextMessage"];
  isModalOpen = false;
  form: FormGroup;

  constructor(
    public readonly list: ListService,
    private fb: FormBuilder,
    private phonesDirectoryService: PhoneDirectoryService,
    private confirmation: ConfirmationService,
    public router: Router
  ) { }

  ngOnInit(): void {
    const phoneDirectoryStreamCreator = (query) => this.phonesDirectoryService.getFilteredList({ ...query, entityId: this.entityId, entityName: this.entityName });
    this.list.hookToQuery(phoneDirectoryStreamCreator).subscribe((response) => {
      this.phoneDirectories = response;
    });
  }

  changePage(pageEvent: PageEvent) {
    this.list.page = pageEvent.pageIndex;
  }

  changeSort(sort: Sort) {
    this.list.sortKey = sort.active;
    this.list.sortOrder = sort.direction;
  }

  createPhone() {
    this.selectedPhone = {} as PhoneDirectoryDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editPhone(id: string) {

    this.phonesDirectoryService.get(id).subscribe((phoneDirectories) => {
      this.selectedPhone = phoneDirectories;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.phonesDirectoryService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      phoneNumber: [this.selectedPhone.phoneNumber || '', Validators.required],
      tenantId: [this.selectedPhone.tenantId],
      entityId: [this.entityId],
      entityName: [this.entityName],
      isPrimary: [this.selectedPhone.isPrimary || false],
      isAcceptTextMessage: [this.selectedPhone.isAcceptTextMessage || false]
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedPhone.id
      ? this.phonesDirectoryService.update(this.selectedPhone.id, this.form.value)
      : this.phonesDirectoryService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}