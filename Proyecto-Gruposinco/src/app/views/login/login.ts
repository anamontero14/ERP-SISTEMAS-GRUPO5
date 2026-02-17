import { Component, effect } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginVM } from '../../../presentation/viewmodels/LoginVM';
import { PaEscribirComponent } from '../../../presentation/components/pa-escribir-component/pa-escribir-component';
import { ButtonComponent } from '../../../presentation/components/button-component/button-component';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-login-screen',
  imports: [CommonModule, FormsModule, PaEscribirComponent, ButtonComponent],
  template: `
    <div class="login-screen">
      <h1>Login</h1>

      <app-pa-escribir
        label="Email"
        type="email"
        [ngModel]="vm.email()"
        (ngModelChange)="vm.email.set($event)"
      ></app-pa-escribir>

      <app-pa-escribir
        label="Password"
        type="password"
        [ngModel]="vm.password()"
        (ngModelChange)="vm.password.set($event)"
      ></app-pa-escribir>

      <app-button
        [label]="vm.loading() ? 'Entrando...' : 'Entrar'"
        [disabled]="vm.loading()"
        (clicked)="vm.login()"
      ></app-button>

      <p *ngIf="vm.error()">{{ vm.error() }}</p>
    </div>
  `,
})
export class LoginScreen {
  constructor(public vm: LoginVM) {
    effect(() => {});
  }
}
