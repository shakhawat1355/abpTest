import { Component, Input, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { EmailDirectoryDto, EmailDirectoryService } from '@proxy/email-directories';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-email-list',
  templateUrl: './email-list.component.html',
  providers: [ListService],
})

export class EmailListComponent implements OnInit {

  @Input() entityId: string;
  @Input() entityName: string;

  selectedEmail = {} as EmailDirectoryDto;
  emailDirectories = { items: [], totalCount: 0 } as PagedResultDto<EmailDirectoryDto>;
  columns: string[] = ["actions", "email", "isPrimary", "optOutForMarketing", "optForDirectMarketing"];
  isModalOpen = false;
  form: FormGroup;

  constructor(
    public readonly list: ListService,
    private fb: FormBuilder,
    private emailsDirectoryService: EmailDirectoryService,
    private confirmation: ConfirmationService,
    public router: Router
  ) { }

  ngOnInit(): void {
    const emailDirectoryStreamCreator = (query) => this.emailsDirectoryService.getFilteredList({ ...query, entityId: this.entityId, entityName: this.entityName });
    this.list.hookToQuery(emailDirectoryStreamCreator).subscribe((response) => {
      this.emailDirectories = response;
    });
  }

  changePage(pageEvent: PageEvent) {
    this.list.page = pageEvent.pageIndex;
  }

  changeSort(sort: Sort) {
    this.list.sortKey = sort.active;
    this.list.sortOrder = sort.direction;
  }

  createEmail() {
    this.selectedEmail = {} as EmailDirectoryDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editEmail(id: string) {

    this.emailsDirectoryService.get(id).subscribe((emailDirectories) => {
      this.selectedEmail = emailDirectories;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.emailsDirectoryService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      email: [this.selectedEmail.email || '', [Validators.required, Validators.email]],
      tenantId: [this.selectedEmail.tenantId],
      entityId: [this.entityId],
      entityName: [this.entityName],
      isPrimary: [this.selectedEmail.isPrimary || false],
      optForDirectMarketing: [this.selectedEmail.optForDirectMarketing || false],
      optOutForMarketing: [this.selectedEmail.optOutForMarketing || false],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedEmail.id
      ? this.emailsDirectoryService.update(this.selectedEmail.id, this.form.value)
      : this.emailsDirectoryService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}