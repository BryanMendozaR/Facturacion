import {HttpClient, provideHttpClient, withInterceptorsFromDi} from '@angular/common/http';
import {ApplicationConfig, importProvidersFrom, provideZoneChangeDetection} from '@angular/core';
import {BrowserAnimationsModule, provideAnimations} from '@angular/platform-browser/animations';
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async';
import {provideRouter} from '@angular/router';
import {ToastrModule} from 'ngx-toastr';
import {routes} from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection(
    {eventCoalescing: true}),
  provideRouter(routes),
  provideAnimationsAsync(),
  provideAnimations(),
  importProvidersFrom(
    HttpClient,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      easeTime: 500,
      tapToDismiss: false,
      closeButton: false,
    }),
  ),
  provideHttpClient(withInterceptorsFromDi())]
};
