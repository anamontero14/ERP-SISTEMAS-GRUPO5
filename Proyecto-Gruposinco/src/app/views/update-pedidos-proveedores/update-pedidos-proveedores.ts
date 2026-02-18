import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { UpdatePedidosProveedoresVM } from '../../../presentation/viewmodels/UpdatePedidosProveedoresVM';
import { clsPedido } from '../../../domain/entities/clsPedido';
import { clsDetallePedido } from '../../../domain/entities/clsDetallePedido';

@Component({
  standalone: true,
  selector: 'app-update-pedidos-proveedores-screen',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './update-pedidos-proveedores.html'
})
export class UpdatePedidosProveedoresScreen implements OnInit {

  pedido!: clsPedido;
  detalles: clsDetallePedido[] = [];

  constructor(
    public vm: UpdatePedidosProveedoresVM,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  async ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    await this.vm.cargarDatos(id);

    this.pedido = this.vm.pedido();
    this.detalles = this.vm.detalles();
  }

  puedeEditar(): boolean {
    return this.pedido.Estado === "pedido" || this.pedido.Estado === "enviado";
  }

  async guardar() {
    await this.vm.actualizarPedido(this.pedido.IdPedido, this.pedido);
    this.router.navigate(['/pedidos']);
  }
}

