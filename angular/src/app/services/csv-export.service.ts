import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Papa } from 'ngx-papaparse';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CsvExportService {

  private baseUrl = environment.apis.default.url + '/api';

  constructor(private http: HttpClient, private papa: Papa) {}

  fetchData(apiUrl: string, queryParams: { [key: string]: any } = {}): Observable<any[]> {

    queryParams = queryParams || {};

    if (!queryParams.hasOwnProperty('skipCount')) {
      queryParams['skipCount'] = 0;
    }
    if (!queryParams.hasOwnProperty('maxResultCount')) {
      queryParams['maxResultCount'] = 1000;
    }

    let url = `${this.baseUrl}/${apiUrl}`;

    let params = new HttpParams();
    for (const key in queryParams) {
      if (queryParams.hasOwnProperty(key)) {
        params = params.set(key, queryParams[key].toString());
      }
    }
    return this.http.get<any[]>(url, { params });
  }


  exportToCsv(filename: string, rows: any[], fieldList?: string[]): void {
    if (!rows || !rows.length) {
      console.error('No data available for CSV export');
      return;
    }

    let filteredRows = rows;
    if (fieldList && fieldList.length > 0) {
      filteredRows = this.filterFields(rows, fieldList);
    }
    const csv = this.papa.unparse(filteredRows);
    this.downloadCsv(filename, csv);
  }

  private filterFields(rows: any[], fieldList: string[]): any[] {
    return rows.map(row => {
      const filteredRow = {};
      fieldList.forEach(field => {
        filteredRow[field] = row[field];
      });
      return filteredRow;
    });
  }

  private downloadCsv(filename: string, csv: string): void {
    const blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
    const link = document.createElement('a');
    const url = URL.createObjectURL(blob);

    link.setAttribute('href', url);
    link.setAttribute('download', filename);
    link.style.visibility = 'hidden';

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
}