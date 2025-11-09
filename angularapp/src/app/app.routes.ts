import { Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { AdminDashboardComponent } from './admindashboard/admindashboard';
import { VoterDashboardComponent } from './voterdashboard/voterdashboard';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminDashboardComponent },
  { path: 'voter', component: VoterDashboardComponent },
  { path: '**', redirectTo: 'login' }
];
