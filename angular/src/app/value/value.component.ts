import { Component , OnInit} from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { ValueTypeLookupDto, ValueService, ValueTypeService, ValueTypeDto, ValueDto  } from '@proxy/values';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';  
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrl: './value.component.scss',
  providers: [ListService],
})
export class ValueComponent implements OnInit {
  values = {items:[], totalCount:0} as PagedResultDto<ValueDto>
  selectedValue = {} as ValueDto;
  isModalOpen = false;
  form : FormGroup;
  valueTypes$: Observable<ValueTypeLookupDto[]>;
  constructor(
    public readonly list: ListService,
    private valurTypeService: ValueTypeService,
    private valueService: ValueService,
    private fb : FormBuilder,
    private confirmation : ConfirmationService
  ) 
  {
    this.valueTypes$ = valurTypeService.getValueTypeLookup().pipe(map((r) => r.items));
  }

  ngOnInit(): void {
    const valueStreamCreator=(query)=>this.valueService.getList(query);

    this.list.hookToQuery(valueStreamCreator).subscribe((respones) => {
      this.values=respones;
    });
  }

  buildFrom() {
    this.form = this.fb.group({
      name: [this.selectedValue.name ||'', Validators.required],
      displayOrder: [this.selectedValue.displayOrder || 0 ],  
      isPreSelect: [this.selectedValue.isPreSelect || false], 
      tenantId: [this.selectedValue.tenantId || ''], 
      valueTypeId: [this.selectedValue.valueTypeId || ''], 
    });
  }

  createValue(){
    this.buildFrom();
    this.isModalOpen = true;
  }

  editValue(id: string ){
    this.valueService.get(id).subscribe((value)=>{
      this.selectedValue=value;
      this.buildFrom();
      this.isModalOpen = true;
    })
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedValue.id
      ? this.valueService.update(this.selectedValue.id, this.form.value)
      : this.valueService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.selectedValue={} as ValueDto;
      this.list.get();
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.valueService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
