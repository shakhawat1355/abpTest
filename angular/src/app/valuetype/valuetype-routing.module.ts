import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ValuetypeComponent } from './valuetype.component';

const routes: Routes = [{ path: '', component: ValuetypeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ValuetypeRoutingModule { }
