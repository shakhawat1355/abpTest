import { Component, Input } from '@angular/core';
import { CsvExportService } from '../../services/csv-export.service';

@Component({
  selector: 'app-export-csv',
  template: `<button style="height: 37px;font-family: sans-serif;" class="d-inline-flex align-items-center gap-1 btn btn-sm btn-primary" (click)="handleClick()">
  <i class="me-1 fa fa-file-csv" ng-reflect-ng-class="fa fa-file-csv"></i> Export to CSV</button>`,
})
export class ExportComponent {
    @Input() apiUrl: string;
    @Input() fileName: string;
    @Input() queryParams = {};
    @Input() fieldList?: string[]; 

  constructor(
    private csvExportService: CsvExportService,
  ) {}

  handleClick() {

    this.csvExportService.fetchData(this.apiUrl, this.queryParams).subscribe(
      response => {
        const apiResponse = response as {
          items?: any[];
          totalCount?: number;
        };
        this.csvExportService.exportToCsv(this.fileName + '.csv', apiResponse?.items, this.fieldList);
      },
      error => {
        console.error('Error fetching data', error);
      }
    );

  }
}

