import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoreComponent } from './store-list/store.component';
import { StoreCreateComponent } from './store-create/store-create.component';
import { StoreEditComponent } from './store-edit/store-edit.component';

const routes: Routes = [
  {
    path: "",
    component: StoreComponent,
  },
  {
    path: "list",
    component: StoreComponent,
    data: { title: "Store" },
  },
  {
    path: "create",
    component: StoreCreateComponent,
  },
  {
    path: "edit/:id",
    component: StoreEditComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoreRoutingModule { }
