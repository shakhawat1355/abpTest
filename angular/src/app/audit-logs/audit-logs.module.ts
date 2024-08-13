import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuditLogsRoutingModule } from './audit-logs-routing.module';
import { AuditLogsComponent } from './audit-logs.component';
import { SharedModule } from '../shared/shared.module';
import { AngularMaterialModule } from '../shared/angular-material/angular-material.module';

@NgModule({
  declarations: [
    AuditLogsComponent
  ],
  imports: [
    AngularMaterialModule,
    SharedModule,
    CommonModule,
    AuditLogsRoutingModule
  ]
})
export class AuditLogsModule { }
