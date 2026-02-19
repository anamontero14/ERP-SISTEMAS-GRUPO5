import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginVM } from '../../../presentation/viewmodels/LoginVM';
import { PaEscribirComponent } from '../../../presentation/components/pa-escribir-component/pa-escribir-component';
import { ButtonComponent } from '../../../presentation/components/button-component/button-component';

@Component({
  standalone: true,
  selector: 'app-login-screen',
  imports: [CommonModule, FormsModule, PaEscribirComponent, ButtonComponent],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginScreen {
  // Injectamos el VM directamente (suponiendo que está proveído en el root o el componente)
  constructor(public vm: LoginVM) {}
}
