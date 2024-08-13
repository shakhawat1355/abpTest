import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { VehicleService, VehicleDto } from '@proxy/vehicles';
import { ValueTypeService } from '@proxy/values/value-type.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ValueTypeLookupDto } from '@proxy/values';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { EXPORT_CONFIG } from '../export/export-config';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrl: './vehicle.component.scss',
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }
  ],
})
export class VehicleComponent implements OnInit {
  exportUrl = EXPORT_CONFIG.vehicleUrl;

  exportFieldList = ['licensePlate', 'vin', 'model', 'statusValue', 'expirationDate', 'maintenanceDue'];

  vehicle = { items: [], totalCount: 0 } as PagedResultDto<VehicleDto>;
  isModalOpen = false;
  form: FormGroup;
  selectedVehicle = {} as VehicleDto;
  pValueList$: Observable<ValueTypeLookupDto[]>;

  constructor(
    public readonly list: ListService, 
    private vehicleService: VehicleService,
    private fb: FormBuilder,
    private valueTypeService: ValueTypeService,
    private confirmation: ConfirmationService
  ) {
    this.pValueList$ = valueTypeService.getValueTypeLookup().pipe(map((r) => r.items));
  }

  ngOnInit() {
    const vehicleStreamCreator = (query) => this.vehicleService.getList(query);

    this.list.hookToQuery(vehicleStreamCreator).subscribe((response) => {
      this.vehicle = response;
    });
  }

  createVehicle() {
    this.selectedVehicle = {} as VehicleDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editVehicle(id: string) {
    this.vehicleService.get(id).subscribe((vehicle) => {
      this.selectedVehicle = vehicle;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.vehicleService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      licensePlate: [this.selectedVehicle.licensePlate || '', Validators.required],
      vin: [this.selectedVehicle.vin || '', Validators.required],
      model: [this.selectedVehicle.model || ''],
      statusValueId: [this.selectedVehicle.statusValueId || '', Validators.required],
      expirationDate: [
        this.selectedVehicle.expirationDate ? new Date(this.selectedVehicle.expirationDate) : null,
      ],
      maintenanceDue: [
        this.selectedVehicle.maintenanceDue ? new Date(this.selectedVehicle.maintenanceDue) : null,
      ]
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedVehicle.id
      ? this.vehicleService.update(this.selectedVehicle.id, this.form.value)
      : this.vehicleService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
