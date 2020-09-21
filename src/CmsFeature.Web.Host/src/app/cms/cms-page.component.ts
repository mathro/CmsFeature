import { Component, OnDestroy } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    CmsServiceProxy,
    CmsDto
} from '@shared/service-proxies/service-proxies';
import { Params, ActivatedRoute, NavigationEnd, Router } from '@angular/router';

@Component({
    templateUrl: './cms-page.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
      ]
})
export class CmsPageComponent implements OnDestroy {
    navigationSubscription: any;
    cmsPage: CmsDto;
    id: number;

    constructor(
        private _cmsService: CmsServiceProxy,
        private _activeRoute: ActivatedRoute,
        private _router: Router
    ) {
        this.navigationSubscription = this._router.events.subscribe((e: any) => {
          if (e instanceof NavigationEnd) {
            this.initializeCmsPage();
          }
        });
    }

    initializeCmsPage() {
      this._activeRoute.params.subscribe((params: Params) => {
          this.id = +params['id'];
      });

      this._cmsService
          .get(this.id)
          .subscribe((result: CmsDto) => {
              this.cmsPage = result;
          });
    }

    ngOnDestroy() {
      if (this.navigationSubscription) {
          this.navigationSubscription.unsubscribe();
        }
    }
}