import { Component, Injector, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
    CmsServiceProxy,
    CmsDto,
    PagedResultDtoOfCmsDto
} from '@shared/service-proxies/service-proxies';
import { CreateCmsDialogComponent } from './create-cms/create-cms-dialog.component';
import { EditCmsDialogComponent } from './edit-cms/edit-cms-dialog.component';
import { NavigationEnd, Route, Router } from '@angular/router';

class PagedCmsRequestDto extends PagedRequestDto {
    keyword: string;
    isActive: boolean | null;
}

@Component({
    templateUrl: './cms.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
      ]
})
export class CmsComponent extends PagedListingComponentBase<CmsDto> {
    cms: CmsDto[] = [];
    keyword = '';
    isActive: boolean | null;

    constructor(
        injector: Injector,
        private _cmsService: CmsServiceProxy,
        private _dialog: MatDialog,
        private _router: Router
    ) {
        super(injector);

        this._router.routeReuseStrategy.shouldReuseRoute = function () {
            return false;
          };
    }

    list(
        request: PagedCmsRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;
        request.isActive = this.isActive;

        this._cmsService
            .getAll(request.keyword, request.isActive, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfCmsDto) => {
                this.cms = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    delete(cms: CmsDto): void {
    }

    createCms(): void {
        this.showCreateOrEditCmsDialog();
    }

    editCms(cms: CmsDto): void {
        this.showCreateOrEditCmsDialog(cms.id);
    }

    showCreateOrEditCmsDialog(id?: number): void {
        let createOrEditCmsDialog : any;
        if (id === undefined || id <= 0) {
            createOrEditCmsDialog = this._dialog.open(CreateCmsDialogComponent);
        } else {
            createOrEditCmsDialog = this._dialog.open(EditCmsDialogComponent, {
                data: id
            });
        }

        createOrEditCmsDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
                this._router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
                    this._router.navigate(['/app/cms']);
                }); 
            }
        });
    }
}
