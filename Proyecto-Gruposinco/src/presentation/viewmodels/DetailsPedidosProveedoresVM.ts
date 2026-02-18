import { Injectable, signal } from '@angular/core';
import { GetPedidosUseCase } from '../../domain/usecases/pedido_fix/GetPedidosUseCase';
import { GetDetallesPedidoUseCase } from '../../domain/usecases/detallePedido/GetDetallesPedidoUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';
import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class DetailsPedidosProveedoresVM {

  loading = signal(true);
  pedido = signal<clsPedido | null>(null);
  detalles = signal<clsDetallePedido[]>([]);

  constructor(
    private getPedidoUC: GetPedidosUseCase,
    private getDetallesUC: GetDetallesPedidoUseCase
  ) {}

  async cargarDatos(idPedido: number) {
    this.loading.set(true);

    const p = await this.getPedidoUC.getPedidoPorId(idPedido);
    const d = await this.getDetallesUC.getListaDetallesPorPedido(idPedido);

    this.pedido.set(p);
    this.detalles.set(d);

    this.loading.set(false);
  }
}
