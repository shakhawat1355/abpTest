import { CoreModule } from '@abp/ng.core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ExportComponent } from './components/export.component';
import { ImportComponent } from './components/import.component';

@NgModule({
  declarations: [ExportComponent, ImportComponent],
  imports: [CoreModule, ThemeSharedModule, NgbDropdownModule, NgxValidateCoreModule],
  exports: [
    CoreModule,
    ThemeSharedModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    ExportComponent,
    ImportComponent
  ],
  providers: [],
})
export class SharedModule {}
