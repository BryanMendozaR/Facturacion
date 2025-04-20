import {HttpClient, provideHttpClient, withInterceptorsFromDi} from '@angular/common/http';
import {ApplicationConfig, importProvidersFrom, provideZoneChangeDetection} from '@angular/core';
import {provideRouter} from '@angular/router';

import {provideAnimationsAsync} from '@angular/platform-browser/animations/async';
import {routes} from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({eventCoalescing: true}), provideRouter(routes), provideAnimationsAsync(), importProvidersFrom(HttpClient), provideHttpClient(withInterceptorsFromDi())]
};
