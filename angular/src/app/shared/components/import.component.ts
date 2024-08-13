import { Component, Input } from '@angular/core';
import { CsvExportService } from '../../services/csv-export.service';
import * as XLSX from 'xlsx';


@Component({
  selector: 'app-import-data',
  template: `<input type="file" #fileInput (change)="onFileChange($event)" style="" accept=".xlsx, .xls,.csv">`,
})
export class ImportComponent {
    @Input() apiUrl: string;
    @Input() fileName: string;
    @Input() queryParams = {};
    @Input() fieldList?: string[]; 

  constructor(
    private csvExportService: CsvExportService,
  ) {}

  onFileChange(evt: any) {
    const target: DataTransfer = <DataTransfer>(evt.target);
    if (target.files.length !== 1) {
      console.error('Cannot use multiple files');
      return;
    }
    const reader: FileReader = new FileReader();
    reader.onload = (e: any) => {
      /* Read workbook */
      const bstr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      /* Grab the first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      /* Convert array of arrays */
      const data = XLSX.utils.sheet_to_json(ws, { header: 1 });

      /* Update state */
      console.log("Data in JSON format:", JSON.stringify(data));
      
      const formattedJson = this.jsonFormatter(data);
      console.log(JSON.stringify(formattedJson));
    };

    reader.readAsBinaryString(target.files[0]);
  }
  

  handleClick() {
    console.log('File clicked');

    // this.csvExportService.fetchData(this.apiUrl, this.queryParams).subscribe(
    //   response => {
    //     const apiResponse = response as {
    //       items?: any[];
    //       totalCount?: number;
    //     };
    //     this.csvExportService.exportToCsv(this.fileName + '.csv', apiResponse?.items, this.fieldList);
    //   },
    //   error => {
    //     console.error('Error fetching data', error);
    //   }
    // );

  }

  jsonFormatter(data){
    const headers = data[0]; // First element as headers
    const result = [];

    for (let i = 1; i < data.length; i++) {
        let obj = {};
        for (let j = 0; j < headers.length; j++) {
            obj[headers[j]] = data[i][j] === undefined ? null : data[i][j];
        }
        result.push(obj);
    }

    return result;
  }
}

