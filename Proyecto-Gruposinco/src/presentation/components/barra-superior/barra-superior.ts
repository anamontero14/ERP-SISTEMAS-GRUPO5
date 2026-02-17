import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../services/AuthService';

@Component({
  selector: 'app-barra-superior',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './barra-superior.html',
  styleUrls: ['./barra-superior.css'],
})
export class BarraSuperior {
  constructor(private auth: AuthService) {}

  logout() {
    this.auth.logout();
  }
}
