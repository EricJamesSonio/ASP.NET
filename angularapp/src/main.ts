import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import 'zone.js';
import { App } from './app/app';
import { routes } from './app/app.routes'; 

bootstrapApplication(App, {
  providers: [
    provideHttpClient(),      // HttpClient available globally
    provideRouter(routes)     // use routes from app.routes.ts
  ]
}).catch(err => console.error(err));