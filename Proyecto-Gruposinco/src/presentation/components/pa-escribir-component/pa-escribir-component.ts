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
  @Input() label: string = '';
  @Input() type: string = 'text';

  value: any = '';
  disabled = false;

  onChange = (value: any) => {};
  onTouched = () => {};

  writeValue(value: any): void {
    this.value = value || '';
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  onInput(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.value = target.value;
    this.onChange(this.value);
  }
}
