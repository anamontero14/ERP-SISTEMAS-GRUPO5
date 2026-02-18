import { Injectable, signal } from '@angular/core';
import { GetPedidosUseCase } from '../../domain/usecases/pedido/GetPedidosUseCase';
import { UpdatePedidoUseCase } from '../../domain/usecases/pedido/UpdatePedidoUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';
import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';
import { GetDetallesPedidoUseCase } from '../../domain/usecases/detallePedido/GetDetallesPedidoUseCase';
import { UpdateDetallePedidoUseCase } from '../../domain/usecases/detallePedido/UpdateDetallePedidoUseCase';

@Injectable({ providedIn: 'root' })
export class UpdatePedidosProveedoresVM {

  pedido = signal<clsPedido>(null as any);
  detalles = signal<clsDetallePedido[]>([]);

  constructor(
    private getPedidoUC: GetPedidosUseCase,
    private updatePedidoUC: UpdatePedidoUseCase,
    private getDetallesUC: GetDetallesPedidoUseCase
  ) {}

  async cargarDatos(idPedido: number) {
    const p = await this.getPedidoUC.getPedidoPorId(idPedido);
    const dets = await this.getDetallesUC.getListaDetallesPorPedido(idPedido);

    this.pedido.set(p);
    this.detalles.set(dets);
  }

  async actualizarPedido(idPedido: number, pedido: clsPedido) {
    await this.updatePedidoUC.actualizarPedido(idPedido, pedido);
  }
  
  
}
