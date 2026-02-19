import { Injectable, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/AuthService';

@Injectable({ providedIn: 'root' })
export class LoginVM {
  email = signal<string>('');
  password = signal<string>('');
  loading = signal<boolean>(false);
  error = signal<string | null>(null);

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  async login() {
    this.loading.set(true);
    this.error.set(null);

    try {
      await this.authService.login(this.email(), this.password());
      await this.router.navigate(['/welcome']);
    } catch (err: any) {
      this.error.set('Email o contraseña incorrectos');
    } finally {
      this.loading.set(false);
    }
  }
}