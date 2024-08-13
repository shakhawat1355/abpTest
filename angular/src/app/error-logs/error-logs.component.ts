import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ErrorLogDto, ErrorLogService } from '@proxy/logs';

const LogLevel = {
  Debug: 1,
  Info: 2,
  Warning: 4,
  'System Error': 8,
  Critical: 16,
};

@Component({
  selector: 'app-error-logs',
  templateUrl: './error-logs.component.html',
  styleUrl: './error-logs.component.scss',
  providers: [ListService, DatePipe],
})
export class ErrorLogsComponent implements OnInit {
  errorLogs: PagedResultDto<ErrorLogDto> = { items: [], totalCount: 0 };
  searchForm: FormGroup;
  logLevels: any[];
  dataSource = new MatTableDataSource<ErrorLogDto>();
  displayedColumns: string[] = [
    'logLevel',
    'shortMessage',
    'fullMessage',
    'ipAddress',
    'creationTime',
  ];

  @ViewChild(MatSort) sort: MatSort;

  constructor(
    public readonly list: ListService,
    private errorLogService: ErrorLogService,
    private fb: FormBuilder,
    private datePipe: DatePipe
  ) {
    this.logLevels = Object.keys(LogLevel).map(key => {
      return { text: key, value: LogLevel[key] };
    });
  }

  ngOnInit(): void {
    this.searchForm = this.fb.group({
      logLevel: [null],
      startDate: [null],
      endDate: [null],
    });

    this.searchForm.valueChanges.subscribe(() => {
      this.onSearch();
    });

    const errorLogStreamCreator = query => this.errorLogService.getList(query);
    this.list.hookToQuery(errorLogStreamCreator).subscribe(response => {
      this.errorLogs = response;
      this.dataSource.data = response.items;
      this.dataSource.sort = this.sort;
    });
  }

  onSearch(): void {
    const searchCriteria = this.searchForm.value;
    const input = new PagedAndSortedResultRequestDto();

    const startDate = searchCriteria.startDate
      ? this.datePipe.transform(searchCriteria.startDate, 'yyyy-MM-dd')
      : null;
    const endDate = searchCriteria.endDate
      ? this.datePipe.transform(searchCriteria.endDate, 'yyyy-MM-dd')
      : null;

    this.errorLogService
      .getByFilter(searchCriteria.logLevel, startDate, endDate, input)
      .subscribe(response => {
        this.errorLogs = response;
        this.dataSource.data = response.items;
        this.dataSource.sort = this.sort;
      });
  }

  formatCreationTime(date: string): string {
    return this.datePipe.transform(date, 'MM/dd/yyyy') ?? '';
  }

  clearStartDate() {
    this.searchForm.get('startDate').setValue(null);
  }
  clearEndDate() {
    this.searchForm.get('endDate').setValue(null);
  }
}
