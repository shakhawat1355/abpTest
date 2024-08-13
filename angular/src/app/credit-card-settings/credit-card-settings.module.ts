import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreditCardSettingsRoutingModule } from './credit-card-settings-routing.module';
import { CreditCardSettingsComponent } from './credit-card-settings.component';
import { SharedModule } from '../shared/shared.module';
import { AngularMaterialModule } from '../shared/angular-material/angular-material.module';


@NgModule({
  declarations: [
    CreditCardSettingsComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    CreditCardSettingsRoutingModule,
    AngularMaterialModule
  ]
})
export class CreditCardSettingsModule { }
