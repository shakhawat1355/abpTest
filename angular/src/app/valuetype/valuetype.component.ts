import { Component , OnInit} from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ValueTypeLookupDto, ValueTypeService, ValueTypeDto,  } from '@proxy/values';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';  
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-valuetype',
  templateUrl: './valuetype.component.html',
  styleUrl: './valuetype.component.scss',
  providers: [ListService],
})
export class ValuetypeComponent implements OnInit {
  valueTypes = {items:[], totalCount:0} as PagedResultDto<ValueTypeDto>
  selectedValueType = {} as ValueTypeDto;
  isModalOpen = false;
  form : FormGroup;
  pValueTypes$: Observable<ValueTypeLookupDto[]>;
  constructor(
    public readonly list: ListService,
    private valurTypeService: ValueTypeService,
    private fb : FormBuilder,
    private confirmation : ConfirmationService
  ) 
  {
    this.pValueTypes$ = valurTypeService.getValueTypeLookup().pipe(map((r) => r.items));
  }

  ngOnInit(): void {
    const valueTypeStreamCreator=(query)=>this.valurTypeService.getList(query);

    this.list.hookToQuery(valueTypeStreamCreator).subscribe((respones) => {
      this.valueTypes=respones;
    });
  }

  buildFrom() {
    this.form = this.fb.group({
      name: [this.selectedValueType.name ||'', Validators.required],
      displayOrder: [this.selectedValueType.displayOrder || 0 ],  
      isActive: [this.selectedValueType.isActive || false], 
      tenantId: [this.selectedValueType.tenantId || ''], 
      parentId: [this.selectedValueType.parentId || ''], 
    });
  }

  createValueType(){
    this.buildFrom();
    this.isModalOpen = true;
  }

  editValueType(id: string ){
    this.valurTypeService.get(id).subscribe((valueType)=>{
      this.selectedValueType=valueType;
      this.buildFrom();
      this.isModalOpen = true;
    })
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedValueType.id
      ? this.valurTypeService.update(this.selectedValueType.id, this.form.value)
      : this.valurTypeService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.selectedValueType={} as ValueTypeDto;
      this.list.get();
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.valurTypeService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
