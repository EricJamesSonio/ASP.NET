import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';

import { App } from './app/app';
import { LoginComponent } from './app/login/login';
import { AdminDashboardComponent } from './app/admindashboard/admindashboard';
import { VoterDashboardComponent } from './app/voterdashboard/voterdashboard';

bootstrapApplication(App, {
  providers: [
    provideRouter([
      { path: 'login', component: LoginComponent },
      { path: 'admin', component: AdminDashboardComponent },
      { path: 'voter', component: VoterDashboardComponent },
      { path: '**', redirectTo: 'login' }
    ]),
    provideHttpClient(), // provides HttpClient to all services
  ]
}).catch(err => console.error(err));
