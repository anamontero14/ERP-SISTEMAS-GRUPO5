import { Component, OnInit } from '@angular/core';
import { BarraSuperior } from '../../../presentation/components/barra-superior/barra-superior';
import { FormsModule } from '@angular/forms';
import { CreatePedidosProveedoresVM } from '../../../presentation/viewmodels/CreatePedidosProveedoresVM';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { clsPedido } from '../../../domain/entities/clsPedido';

@Component({
  standalone: true,
  selector: 'app-create-pedidos-proveedores-screen',
  imports: [CommonModule, FormsModule],
  templateUrl: './create-pedidos-proveedores.html',
})
export class CreatePedidosProveedoresScreen implements OnInit {
  idProveedor!: number;
  idProducto!: number;
  cantidad: number = 1;
  observaciones: string = '';
  total: number = 0;

  constructor(public vm: CreatePedidosProveedoresVM, private router: Router) {}

  ngOnInit(): void {
    this.vm.cargarDatos();
  }

  actualizarPrecio() {
    const producto = this.vm.productos().find(p => p.IdProducto === this.idProducto);
    const precio = producto?.PrecioProducto ?? 0;
    this.total = precio * this.cantidad;
  }

  async crear() {
    const pedido = new clsPedido(
      0,
      1,
      this.idProveedor,
      new Date(),
      "pedido",
      this.observaciones ?? "",
      false
    );

    const id = await this.vm.crearPedidoConDetalle(
      pedido,
      this.idProducto,
      this.cantidad
    );

    if (id) {
      this.router.navigate(['/pedidos', id]);
    }
  }
}
