import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { StoreService, StoreDto } from '@proxy/stores';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss',
  providers: [ListService],
})
export class StoreComponent implements OnInit {

  stores = { items: [], totalCount: 0 } as PagedResultDto<StoreDto>
  columns: string[] = ["actions", "storeName", "storeCode", "contactName", "email", "addressLine1", "city", "isPrimaryStore"];
  constructor(
    public readonly list: ListService,
    private storeService: StoreService,
    private confirmation: ConfirmationService
  ) { }

  ngOnInit(): void {
    const valueStreamCreator = (query) => this.storeService.getList(query);

    this.list.hookToQuery(valueStreamCreator).subscribe((respones) => {
      this.stores = respones;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.storeService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  changePage(pageEvent: PageEvent) { 
    this.list.page = pageEvent.pageIndex;
   }

  changeSort(sort: Sort) {
    this.list.sortKey = sort.active;
    this.list.sortOrder = sort.direction;
  }
}