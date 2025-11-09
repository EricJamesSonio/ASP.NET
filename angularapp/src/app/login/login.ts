import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';   // for *ngIf
import { FormsModule } from '@angular/forms';     // for [(ngModel)]
import { RouterModule, Router } from '@angular/router'; 
import { AuthService, LoginRequest } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,  // ⚡ make it standalone
  imports: [CommonModule, FormsModule, RouterModule], // ⚡ must import used modules
  templateUrl: './login.html',
  styleUrls: ['./login.scss']
})
export class LoginComponent {
  email = '';
  password = '';
  error = '';

  constructor(private auth: AuthService, private router: Router) {}

  login() {
    const request: LoginRequest = { email: this.email, password: this.password };
    this.auth.login(request).subscribe({
      next: user => {
        this.auth.setUser(user);
        if (user.role === 'Admin') {
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/voter']);
        }
      },
      error: err => {
        this.error = 'Invalid email or password';
      }
    });
  }
}
