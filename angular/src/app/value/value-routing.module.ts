import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ValueComponent } from './value.component';

const routes: Routes = [{ path: '', component: ValueComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ValueRoutingModule { }
