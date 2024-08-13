import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

import { ValueRoutingModule } from './value-routing.module';
import { ValueComponent } from './value.component';


@NgModule({
  declarations: [
    ValueComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ValueRoutingModule
  ]
}) 
export class ValueModule { } 
 