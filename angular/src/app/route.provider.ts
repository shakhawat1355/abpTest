import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
    { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
    return () => {
        routesService.add([
            {
                path: '/',
                name: '::Menu:Home',
                iconClass: 'fas fa-home',
                order: 1,
                layout: eLayoutType.application,
            },
            {
                path: '/valuetypes',
                name: '::Menu:ValueType',
                iconClass: 'fas fa-home',
                order: 2,
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.ValueTypes'
            },
            {
                path: '/values',
                name: '::Menu:Value',
                iconClass: 'fas fa-home',
                order: 3,
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Values'
            },
            {
                path: '/customerComments',
                name: '::Menu:Customer',
                iconClass: 'fas fa-user',
                order: 4,
                layout: eLayoutType.application,
            },
            {
                path: '/customers',
                name: '::Menu:CustomerList',
                iconClass: 'fas fa-user',
                parentName: '::Menu:Customer',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Customers',
            },
            {
                path: '/customerComments',
                name: '::Menu:Comments',
                iconClass: 'fas fa-comment',
                parentName: '::Menu:Customer',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.CustomerComments',
            },
            {
                path: '/emailDirectories',
                name: '::Menu:Directory',
                iconClass: 'fas fa-book',
                order: 5,
                layout: eLayoutType.application,
            },
            {
                path: '/emailDirectories',
                name: '::Menu:EmailDirectory',
                iconClass: 'fas fa-envelope',
                parentName: '::Menu:Directory',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.EmailDirectory',
            },
            {
                path: '/phoneDirectories',
                name: '::Menu:PhoneDirectory',
                iconClass: 'fas fa-phone',
                parentName: '::Menu:Directory',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.PhoneDirectory',
            },
            {
                path: '/vehicles',
                name: '::Menu:Vehicles',
                iconClass: 'fas fa-truck',
                order: 7,
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Vehicles',
            },
            {
                path: '/shops',
                name: '::Menu:Shop',
                iconClass: 'fas fa-store',
                order: 8,
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Shops'
            },
            {
                path: '/stores',
                name: '::Menu:Stores',
                iconClass: 'fas fa-store',
                order: 9,
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Stores'
            },

            {
                name: '::Menu:Settings',
                iconClass: 'fas fa-cogs',
                order: 10,
                layout: eLayoutType.application,
            },
            {
                path: '/corporateSettings',
                name: '::Menu:CorporateSettings',
                parentName: '::Menu:Settings',
                iconClass: 'fas fa-users',
                order: 1,
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.CorporateSettings'
            },
            {
                path: '/credit-card-settings',
                name: '::Menu:CreditCardSettings',
                parentName: '::Menu:Settings',
                iconClass: 'fas fa-cogs',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.CreditCardSettings'
            },
            {
                path: '/valuetypesettings',
                name: '::Menu:ValueTypeSettings',
                parentName: '::Menu:Settings',
                iconClass: 'fas fa-table',
                order: 2,
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.ValueTypeSettings'
            },
            {
                path: '/logs',
                name: '::Menu:Logs',
                iconClass: 'fas fa-list',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Logs',
            },
            {
                path: '/error-logs',
                name: '::Menu:ErrorLogs',
                iconClass: 'fas fa-list',
                parentName: '::Menu:Logs',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Logs'
            },
            {
                path: '/audit-logs',
                name: '::Menu:AuditLogs',
                iconClass: 'fas fa-list',
                parentName: '::Menu:Logs',
                layout: eLayoutType.application,
                requiredPolicy: 'ClientPortal.Logs',
            }
        ]);
    };
}
