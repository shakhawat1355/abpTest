import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';
import { ValuetypeRoutingModule } from './valuetype-routing.module';
import { ValuetypeComponent } from './valuetype.component'; 
 


@NgModule({
  declarations: [
    ValuetypeComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    ValuetypeRoutingModule
  ]
})
export class ValuetypeModule { } 
 
 