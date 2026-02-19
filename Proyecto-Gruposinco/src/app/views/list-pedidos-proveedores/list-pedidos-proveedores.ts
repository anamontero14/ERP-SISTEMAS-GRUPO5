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
  templateUrl: './list-pedidos-proveedores.html',
  styleUrl: './list-pedidos-proveedores.css',
})
export class ListPedidosProveedores implements OnInit {
  constructor(public vm: ListadoPedidosProveedoresVM) {}

  ngOnInit(): void {
    this.vm.cargarPedidos();
  }
}
