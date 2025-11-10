import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

export interface LoginRequest {
  email: string;
  password: string;
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  role: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(request: LoginRequest): Observable<User> {
    return this.http.post<User>(`${environment.apiUrl}/user/login`, request);
  }

  register(user: any): Observable<User> {
    return this.http.post<User>(`${environment.apiUrl}/user/register`, user);
  }

  logout() {
    localStorage.removeItem('user');
  }

  setUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUser(): User | null {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
  }
}
