import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomersRoutingModule } from './customers-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CustomerComponent } from './customer.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCard, MatCardHeader, MatCardActions, MatCardContent, MatCardFooter, MatCardTitle, MatCardTitleGroup } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import {MatExpansionModule} from '@angular/material/expansion';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerCreateComponent } from './customer-create/customer-create.component';
import { CustomerEditComponent } from './customer-edit/customer-edit.component';
import { EmailListComponent } from './email-list/email-list.component';
import { PhoneListComponent } from './phone-list/phone-list.component';


@NgModule({
  declarations: [ CustomerComponent, CustomerListComponent, CustomerCreateComponent, CustomerEditComponent, EmailListComponent, PhoneListComponent],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    SharedModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    MatCard,
    MatCardHeader,
    MatCardActions,
    MatCardContent,
    MatCardFooter,
    MatCardTitle,
    MatCardTitleGroup,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatExpansionModule
  ]
})
export class CustomersModule { }
