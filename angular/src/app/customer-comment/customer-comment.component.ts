import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CustomerCommentService, CustomerCommentDto } from '@proxy/customer-comments';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-customer-comment',
  templateUrl: './customer-comment.component.html',
  styleUrl: './customer-comment.component.scss',
  providers: [ListService],
})
export class CustomerCommentComponent implements OnInit {
  comment = { items: [], totalCount: 0 } as PagedResultDto<CustomerCommentDto>;
  selectedComment = {} as CustomerCommentDto;
  form: FormGroup;
  isModalOpen = false;

  constructor(
    public readonly list: ListService, 
    private customerCommentService: CustomerCommentService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const commentStreamCreator = (query) => this.customerCommentService.getList(query);

    this.list.hookToQuery(commentStreamCreator).subscribe((response) => {
      this.comment = response;
    });
  }


  createComment() {
    this.selectedComment = {} as CustomerCommentDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editComment(id: string) {
    this.customerCommentService.get(id).subscribe((comment) => {
      this.selectedComment = comment;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.customerCommentService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      comment: [this.selectedComment.comment || '', Validators.required],
      commentAsLocationNote: [this.selectedComment.commentAsLocationNote || false]
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedComment.id
      ? this.customerCommentService.update(this.selectedComment.id, this.form.value)
      : this.customerCommentService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
