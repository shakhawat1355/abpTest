import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DatePipe } from '@angular/common';
import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { AuditLogDto, AuditLogService, AuditTypeLookupDto, AuditTypeService } from '@proxy/logs';

@Component({
  selector: 'app-audit-logs',
  templateUrl: './audit-logs.component.html',
  styleUrls: ['./audit-logs.component.scss'],
  providers: [ListService, DatePipe],
})
export class AuditLogsComponent implements OnInit {
  auditLogs: PagedResultDto<AuditLogDto> = { items: [], totalCount: 0 };
  auditTypes$: Observable<AuditTypeLookupDto[]>;
  searchForm: FormGroup;
  dataSource = new MatTableDataSource<AuditLogDto>();
  displayedColumns: string[] = ['auditType', 'comment', 'ipAddress', 'creationTime'];

  @ViewChild(MatSort) sort: MatSort;

  constructor(
    public readonly list: ListService,
    private auditLogService: AuditLogService,
    private fb: FormBuilder,
    private datePipe: DatePipe,
    auditTypeService: AuditTypeService
  ) {
    this.auditTypes$ = auditTypeService.getAuditTypeLookup().pipe(map(e => e.items));
  }

  ngOnInit(): void {
    this.searchForm = this.fb.group({
      systemKeyWord: [null],
      startDate: [null],
      endDate: [null],
    });

    this.searchForm.valueChanges.subscribe(() => {
      this.onSearch();
    });

    const auditLogStreamCerator = query => this.auditLogService.getList(query);
    this.list.hookToQuery(auditLogStreamCerator).subscribe(response => {
      this.auditLogs = response;
      this.dataSource.data = response.items;
      this.dataSource.sort = this.sort;
    });
  }

  formatCreationTime(date: string): string {
    return this.datePipe.transform(date, 'MM/dd/yyyy') ?? '';
  }

  onSearch(): void {
    const searchCriteria = this.searchForm.value;
    const input: PagedAndSortedResultRequestDto = new PagedAndSortedResultRequestDto();

    const startDate = searchCriteria.startDate
      ? this.datePipe.transform(searchCriteria.startDate, 'yyyy-MM-dd')
      : null;
    const endDate = searchCriteria.endDate
      ? this.datePipe.transform(searchCriteria.endDate, 'yyyy-MM-dd')
      : null;

    this.auditLogService
      .getAllByFilter(searchCriteria.systemKeyWord, startDate, endDate, input)
      .subscribe(response => {
        this.auditLogs = response;
        this.dataSource.data = response.items;
        this.dataSource.sort = this.sort;
      });
  }

  clearStartDate() {
    this.searchForm.get('startDate').setValue(null);
  }
  clearEndDate() {
    this.searchForm.get('endDate').setValue(null);
  }
}
