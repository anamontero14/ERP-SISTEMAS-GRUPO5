import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-button',
  imports: [CommonModule],
  templateUrl: './button-component.html',
  styleUrl: './button-component.css'
})
export class ButtonComponent {
  @Input() label: string = 'Entrar';
  @Input() disabled: boolean = false;

  @Output() clicked = new EventEmitter<void>();

  onButtonClick(): void {
    this.clicked.emit();
  }
}
