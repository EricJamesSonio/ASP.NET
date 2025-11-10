import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.html',
  styleUrls: ['./register.scss']
})
export class RegisterComponent {
  firstName = '';
  lastName = '';
  email = '';
  password = '';
  error = '';
  success = '';

  constructor(private auth: AuthService, private router: Router) {}

  register() {
    const newUser = {
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      passwordHash: this.password, // backend expects this field name
      role: 'Voter' // default role
    };

    this.auth.register(newUser).subscribe({
      next: res => {
        this.success = 'Registration successful! You can now log in.';
        setTimeout(() => this.router.navigate(['/login']), 1500);
      },
      error: err => {
        this.error = err.error || 'Registration failed.';
      }
    });
  }
}
