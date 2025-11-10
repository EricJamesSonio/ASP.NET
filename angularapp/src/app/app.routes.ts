// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { RegisterComponent } from './register/register';
import { AdminDashboardComponent } from './admindashboard/admindashboard';
import { VoterDashboardComponent } from './voterdashboard/voterdashboard';
import { RankingComponent } from './ranking/ranking';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'admin', component: AdminDashboardComponent },
  { path: 'voter', component: VoterDashboardComponent },
  { path: 'rank' , component : RankingComponent},
  { path: '**', redirectTo: 'login' } // wildcard
];
