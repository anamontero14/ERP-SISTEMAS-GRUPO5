import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { clsPedido } from '../../../domain/entities/clsPedido';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-pedido-item',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './pedido-item-component.html',
  styleUrls: ['./pedido-item-component.css'],
})
export class PedidoItemComponent {
  @Input() pedido!: clsPedido;
}
