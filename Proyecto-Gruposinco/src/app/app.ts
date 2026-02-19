import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BarraSuperior } from '../presentation/components/barra-superior/barra-superior';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BarraSuperior],
  templateUrl: './app.html'
})
export class AppComponent {}