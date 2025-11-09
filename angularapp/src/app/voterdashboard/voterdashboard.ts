import { Component } from '@angular/core';
import { AuthService, User } from '../services/auth.service';

@Component({
  selector: 'app-voter-dashboard',
  standalone: true,
  templateUrl: './voterdashboard.html'
})
export class VoterDashboardComponent {
  user: User | null = null;

  constructor(private auth: AuthService) {
    this.user = this.auth.getUser();
  }
}
