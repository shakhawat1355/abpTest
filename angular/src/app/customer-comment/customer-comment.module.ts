import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { CustomerCommentRoutingModule } from './customer-comment-routing.module';
import { CustomerCommentComponent } from './customer-comment.component';


@NgModule({
  declarations: [
    CustomerCommentComponent
  ],
  imports: [
    CustomerCommentRoutingModule,
    SharedModule
  ]
})
export class CustomerCommentModule { }
