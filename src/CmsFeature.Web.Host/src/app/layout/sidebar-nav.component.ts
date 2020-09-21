import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';
import { CmsServiceProxy, PagedResultDtoOfCmsDto, CmsDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

    cmsPages: CmsDto[];
    menuItems: MenuItem[];
    arePagesLoading: boolean;

    constructor(
        injector: Injector
        , private _cmsService: CmsServiceProxy,
    ) {
        super(injector);
        this.listAll(() => {
            this.arePagesLoading = false;
        });
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }

    listAll(finishedCallback: Function){
        this._cmsService
        .getAll(undefined, undefined, undefined, undefined)
        .pipe(
            finalize(() => {
                finishedCallback();
            })
        )
        .subscribe((result: PagedResultDtoOfCmsDto) => {
            this.cmsPages = result.items;
            this.setMenuItems(result.items);
        });
    }

    setMenuItems(cmsPages: CmsDto[]) {
        let cmsMenuItems: MenuItem[] = [new MenuItem(this.l('CMS'), 'Pages.Cms', 'business', '/app/cms')];

        cmsPages.filter(x => x.pageName.length > 0 && x.pageContent.length > 0).forEach(page => {
            cmsMenuItems = cmsMenuItems.concat( new MenuItem(this.l(page.pageName), '', 'info', `/app/cms-page/${page.id}`) )
        });

        cmsMenuItems = cmsMenuItems.concat(
            new MenuItem(this.l('MultiLevelMenu'), '', 'menu', '', [
                new MenuItem('ASP.NET Boilerplate', '', '', '', [
                    new MenuItem('Home', '', '', 'https://aspnetboilerplate.com/?ref=abptmpl'),
                    new MenuItem('Templates', '', '', 'https://aspnetboilerplate.com/Templates?ref=abptmpl'),
                    new MenuItem('Samples', '', '', 'https://aspnetboilerplate.com/Samples?ref=abptmpl'),
                    new MenuItem('Documents', '', '', 'https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl')
                ]),
                new MenuItem('ASP.NET Zero', '', '', '', [
                    new MenuItem('Home', '', '', 'https://aspnetzero.com?ref=abptmpl'),
                    new MenuItem('Description', '', '', 'https://aspnetzero.com/?ref=abptmpl#description'),
                    new MenuItem('Features', '', '', 'https://aspnetzero.com/?ref=abptmpl#features'),
                    new MenuItem('Pricing', '', '', 'https://aspnetzero.com/?ref=abptmpl#pricing'),
                    new MenuItem('Faq', '', '', 'https://aspnetzero.com/Faq?ref=abptmpl'),
                    new MenuItem('Documents', '', '', 'https://aspnetzero.com/Documents?ref=abptmpl')
                ])
            ])
        );

        this.menuItems = [
            new MenuItem(this.l('HomePage'), '', 'home', '/app/home'),
            new MenuItem(this.l('Tenants'), 'Pages.Tenants', 'business', '/app/tenants'),
            new MenuItem(this.l('Users'), 'Pages.Users', 'people', '/app/users'),
            new MenuItem(this.l('Roles'), 'Pages.Roles', 'local_offer', '/app/roles'),
            new MenuItem(this.l('About'), '', 'info', '/app/about'),
        ].concat(cmsMenuItems);
    }
}
