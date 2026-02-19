import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './welcome.html',
  styleUrl: './welcome.css', // Recuerda: styleUrl en singular
})
export class WelcomeComponent {}
