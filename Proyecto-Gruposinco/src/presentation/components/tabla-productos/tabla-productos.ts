import { Component, Input } from '@angular/core';
import { CommonModule, DecimalPipe } from '@angular/common';
import { clsProducto } from '../../../domain/entities/clsProducto';

@Component({
  standalone: true,
  selector: 'app-tabla-productos',
  imports: [CommonModule, DecimalPipe],
  template: `
    <table>
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Descripción</th>
          <th>Precio</th>
          <th>Stock</th>
        </tr>
      </thead>
      <tbody>
        <tr *ngFor="let p of productos">
          <td>{{ p.NombreProducto }}</td>
          <td>{{ p.DescripcionProducto }}</td>
          <td>{{ p.PrecioProducto | number:'1.2-2' }}</td>
          <td>{{ p.StockProducto }}</td>
        </tr>
      </tbody>
    </table>
  `,
})
export class TablaProductosComponent {
  @Input() productos: clsProducto[] = [];
}
