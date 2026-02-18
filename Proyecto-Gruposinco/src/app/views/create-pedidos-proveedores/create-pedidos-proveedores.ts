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
  templateUrl: './create-pedidos-proveedores.html'
})
export class CreatePedidosProveedoresScreen implements OnInit {

  idProveedor = 0;
  idProducto = 0;
  cantidad = 1;
  observaciones = "";

  constructor(
    public vm: CreatePedidosProveedoresVM,
    private router: Router
  ) {}

  async ngOnInit() {
    await this.vm.cargarDatos();
  }

  agregar() {
    this.vm.agregarDetalle(this.idProducto, this.cantidad);
  }

  async crear() {
    const idUsuario = 1; // o el que corresponda

    const ok = await this.vm.crearPedidoCompleto(
      idUsuario,
      this.idProveedor,
      this.observaciones
    );

    if (ok) this.router.navigate(['/pedidos']);
  }
}
