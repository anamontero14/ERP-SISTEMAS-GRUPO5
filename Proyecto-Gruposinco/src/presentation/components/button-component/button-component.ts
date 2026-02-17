import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-button',
  imports: [CommonModule],
  template: `
    <button (click)="clicked.emit()" [disabled]="disabled">
      {{ label }}
    </button>
  `,
})
export class ButtonComponent {
  @Input() label = '';
  @Input() disabled = false;

  @Output() clicked = new EventEmitter<void>();
}
