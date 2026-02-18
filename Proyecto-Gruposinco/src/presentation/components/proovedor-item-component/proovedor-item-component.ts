import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { clsProveedor } from '../../../domain/entities/clsProveedor';

@Component({
  selector: 'app-proveedor-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './proovedor-item-component.html',
  styleUrls: ['./proovedor-item-component.css'],
})
export class ProveedorItemComponent {
  @Input() proveedor!: clsProveedor;
}
