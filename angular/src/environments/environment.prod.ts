import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ClientPortal',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44317/',
    redirectUri: baseUrl,
    clientId: 'ClientPortal_App',
    responseType: 'code',
    scope: 'offline_access ClientPortal',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44317',
      rootNamespace: 'MAS.FloraFire.ClientPortal',
    },
  },
} as Environment;
