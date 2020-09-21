import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
  InsertOrUpdateCMSContentDto,
  CmsServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-Cms-dialog.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class CreateCmsDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  cms: InsertOrUpdateCMSContentDto = new InsertOrUpdateCMSContentDto();

  constructor(
    injector: Injector,
    public _cmsService: CmsServiceProxy,
    private _dialogRef: MatDialogRef<CreateCmsDialogComponent>
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._cmsService
      .insertOrUpdate(this.cms)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
}
