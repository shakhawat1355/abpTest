import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { EmailDirectoryService, EmailDirectoryDto } from '@proxy/email-directories';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-email-directory',
  templateUrl: './email-directory.component.html',
  styleUrl: './email-directory.component.scss',
  providers: [ListService],
})
export class EmailDirectoryComponent implements OnInit {
  emailDirectories = { items: [], totalCount: 0 } as PagedResultDto<EmailDirectoryDto>;

  selectedEmail = {} as EmailDirectoryDto;
  form: FormGroup;
  isModalOpen = false;

  constructor(
    public readonly list: ListService, 
    private emailsDirectoryService : EmailDirectoryService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const emailDirectoryStreamCreator = (query) => this.emailsDirectoryService.getList(query);

    this.list.hookToQuery(emailDirectoryStreamCreator).subscribe((response) => {
      this.emailDirectories = response;
    });
  }

   // add new method
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
