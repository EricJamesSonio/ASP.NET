import { Component } from '@angular/core';
import { AuthService, User } from '../services/auth.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admindashboard.html'
})
export class AdminDashboardComponent {
  user: User | null = null;

  constructor(private auth: AuthService) {
    this.user = this.auth.getUser();
  }
}
