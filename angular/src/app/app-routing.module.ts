import { ABP } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { identityToolbarActionContributors } from './export/export-user-contributors';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy({
      toolbarActionContributors: identityToolbarActionContributors,
    })),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'valuetypes', loadChildren: () => import('./valuetype/valuetype.module').then(m => m.ValuetypeModule) },

  { path: 'customers', loadChildren: () => import('./customers/customers.module').then(m => m.CustomersModule)},

  { path: 'customerComments', loadChildren: () => import('./customer-comment/customer-comment.module').then(m => m.CustomerCommentModule) },
  { path: 'values', loadChildren: () => import('./value/value.module').then(m => m.ValueModule) },
  { path: 'emailDirectories', loadChildren: () => import('./email-directory/email-directory.module').then(m => m.EmailDirectoryModule) },
  { path: 'phoneDirectories', loadChildren: () => import('./phone-directory/phone-directory.module').then(m => m.PhoneDirectoryModule) },
  { path: 'corporateSettings', loadChildren: () => import('./corporate-settings/corporate-settings.module').then(m => m.CorporateSettingsModule) },
  { path: 'stores', loadChildren: () => import('./store/store.module').then(m => m.StoreModule) },
  { path: 'vehicles', loadChildren: () => import('./vehicle/vehicle.module').then(m => m.VehicleModule) },
  { path: 'shops', loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule) },
  { path: 'credit-card-settings', loadChildren: () => import('./credit-card-settings/credit-card-settings.module').then(m => m.CreditCardSettingsModule) },
  { path: 'valuetypesettings', loadChildren: () => import('./value-type-settings/value-type-settings.module').then(m => m.ValueTypeSettingsModule) },
  { path: 'audit-logs', loadChildren: () => import('./audit-logs/audit-logs.module').then(m => m.AuditLogsModule) },
  { path: 'error-logs', loadChildren: () => import('./error-logs/error-logs.module').then(m => m.ErrorLogsModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
