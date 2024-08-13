import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ShopService, ShopDto, wireServiceOptions } from '@proxy/shops';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
  providers: [ListService],
})
export class ShopComponent implements OnInit {
  shop = { items: [], totalCount: 0 } as PagedResultDto<ShopDto>;
  selectedShop = {} as ShopDto;
  form: FormGroup;
  isModalOpen = false;
  searchParam = "";
  wireService = wireServiceOptions;

  constructor(
    public readonly list: ListService<ShopDto>, 
    private shopService: ShopService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    const shopStreamCreator = (query) => this.shopService.getFilteredList({...query, filter: this.searchParam});

    this.list.hookToQuery(shopStreamCreator).subscribe((response) => {
      this.shop = response;
    });
  }

  createShop(){
    this.selectedShop = {} as ShopDto;
    this.buildForm(); 
    this.isModalOpen = true;
  }

  editShop(id: string) {
    this.shopService.get(id).subscribe((shop) => {
      this.selectedShop = shop;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedShop.name || '', Validators.required],
      shopCode: [this.selectedShop.shopCode || '', Validators.required],
      zipCode: [this.selectedShop.zipCode || '', Validators.required],
      email: [this.selectedShop.email || ''],
      phone: [this.selectedShop.phone || ''],
      isFFC: [this.selectedShop.isFFC || false],
      openSunday: [this.selectedShop.openSunday || null],
      orderSent: [this.selectedShop.orderSent || null],
      orderReceived: [this.selectedShop.orderReceived || null],
      orderRejected: [this.selectedShop.orderRejected || null],
      wireServiceId: [this.selectedShop.wireServiceId || null],
      isPreferred: [this.selectedShop.isPreferred || false],
      isActive: [this.selectedShop.isActive || false],
      isBlocked: [this.selectedShop.isBlocked || false],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedShop.id
      ? this.shopService.update(this.selectedShop.id, this.form.value)
      : this.shopService.create(this.form.value);
    
    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.shopService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
