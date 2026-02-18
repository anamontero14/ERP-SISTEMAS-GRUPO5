import { Component, Input, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-pa-escribir',
  imports: [CommonModule, FormsModule],
  templateUrl: './pa-escribir-component.html',
  styleUrl: './pa-escribir-component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => PaEscribirComponent),
      multi: true,
    },
  ],
})
export class PaEscribirComponent implements ControlValueAccessor {
  @Input() label = '';
  @Input() type = 'text';

  value: any = '';

  // Métodos obligatorios del ControlValueAccessor
  onChange = (value: any) => {};
  onTouched = () => {};

  writeValue(value: any): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  onInput(event: any) {
    const value = event.target.value;
    this.value = value;
    this.onChange(value);
    this.onTouched();
  }
}
