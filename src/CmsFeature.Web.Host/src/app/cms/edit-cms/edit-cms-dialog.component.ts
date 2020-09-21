import { Component, Injector, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CmsServiceProxy,
  CmsDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-cms-dialog.component.html',
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
export class EditCmsDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  cms: CmsDto = new CmsDto();

  constructor(
    injector: Injector,
    public _cmsService: CmsServiceProxy,
    private _dialogRef: MatDialogRef<EditCmsDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._cmsService.get(this._id).subscribe((result: CmsDto) => {
      this.cms = result;
    });
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
