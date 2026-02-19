import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../services/AuthService';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-barra-superior',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './barra-superior.html',
  styleUrl: './barra-superior.css',
})
export class BarraSuperior {
  menuAbierto = false;

  constructor(private auth: AuthService) {}

  toggleMenu() {
    this.menuAbierto = !this.menuAbierto;
  }

  cerrarMenu() {
    this.menuAbierto = false;
  }

  logout() {
    this.auth.logout();
    this.cerrarMenu(); // Cerramos el menú al salir
  }
}
