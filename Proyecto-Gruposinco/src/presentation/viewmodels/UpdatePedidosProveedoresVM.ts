import { Injectable, signal } from '@angular/core';
import { GetPedidosUseCase } from '../../domain/usecases/pedido/GetPedidosUseCase';
import { UpdatePedidoUseCase } from '../../domain/usecases/pedido/UpdatePedidoUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';

@Injectable({ providedIn: 'root' })
export class UpdatePedidosProveedoresVM {

  pedido = signal<clsPedido>(null as any);

  constructor(
    private getPedidoUC: GetPedidosUseCase,
    private updatePedidoUC: UpdatePedidoUseCase
  ) {}

  async cargarDatos(idPedido: number) {
    const p = await this.getPedidoUC.getPedidoPorId(idPedido);
    this.pedido.set(p);
  }

  async actualizarPedido(idPedido: number, pedido: clsPedido) {
    await this.updatePedidoUC.actualizarPedido(idPedido, pedido);
  }
}
