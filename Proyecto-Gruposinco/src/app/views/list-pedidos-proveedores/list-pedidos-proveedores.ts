import { Component, OnInit } from '@angular/core';
import { BarraSuperior } from '../../../presentation/components/barra-superior/barra-superior';
import { PedidoItemComponent } from '../../../presentation/components/pedido-item-component/pedido-item-component';
import { ListadoPedidosProveedoresVM } from '../../../presentation/viewmodels/ListadoPedidosProovedoresVM';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-list-pedidos-proveedores',
  imports: [CommonModule, PedidoItemComponent, RouterLink],
  template: `
    <div class="list-pedidos">
      <h2>Pedidos a proveedores</h2>
      <a routerLink="/pedidos/create">Crear nuevo pedido</a>

      <div *ngIf="vm.loading()">Cargando...</div>

      <app-pedido-item
        *ngFor="let p of vm.pedidos()"
        [pedido]="p"
      ></app-pedido-item>
    </div>
  `,
})
export class ListPedidosProveedores implements OnInit {
  constructor(public vm: ListadoPedidosProveedoresVM) {}

  ngOnInit(): void {
    this.vm.cargarPedidos();
  }
}
