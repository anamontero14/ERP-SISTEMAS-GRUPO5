import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { clsProducto } from '../../../domain/entities/clsProducto';

@Component({
  selector: 'app-producto-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './producto-item-component.html',
  styleUrls: ['./producto-item-component.css'],
})
export class ProductoItemComponent {
  @Input() producto!: clsProducto;
}
