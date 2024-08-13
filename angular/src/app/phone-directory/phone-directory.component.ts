import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { PhoneDirectoryService, PhoneDirectoryDto, numberTypeOptions } from '@proxy/phone-directories';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-phone-directory',
  templateUrl: './phone-directory.component.html',
  styleUrl: './phone-directory.component.scss',
  providers: [ListService],
})
export class PhoneDirectoryComponent implements OnInit {
  phoneDirectories = { items: [], totalCount: 0 } as PagedResultDto<PhoneDirectoryDto>;

  selectedPhone = {} as PhoneDirectoryDto; 
  form: FormGroup;
  numberTypes = numberTypeOptions;
  isModalOpen = false;

  constructor(
    public readonly list: ListService, 
    private phoneDirectoryService: PhoneDirectoryService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const phoneDirectoryStreamCreator = (query) => this.phoneDirectoryService.getList(query);

    this.list.hookToQuery(phoneDirectoryStreamCreator).subscribe((response) => {
      this.phoneDirectories = response;
    });
  }

  // add new method
  createPhone() {
    this.selectedPhone = {} as PhoneDirectoryDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editPhone(id: string) {
    this.phoneDirectoryService.get(id).subscribe((phoneDirectories) => {
      this.selectedPhone = phoneDirectories;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.phoneDirectoryService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      phoneNumber: [this.selectedPhone.phoneNumber || '', Validators.required],
      isPrimary: [this.selectedPhone.isPrimary || false],
      isAcceptTextMessage: [this.selectedPhone.isAcceptTextMessage || false],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedPhone.id
      ? this.phoneDirectoryService.update(this.selectedPhone.id, this.form.value)
      : this.phoneDirectoryService.create(this.form.value);


      request.subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
  }
}
