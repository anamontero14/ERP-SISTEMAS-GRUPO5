import { Injectable, signal } from '@angular/core';
import { GetPedidosUseCase } from '../../domain/usecases/pedido/GetPedidosUseCase';
import { GetDetallesPedidoUseCase } from '../../domain/usecases/detallePedido/GetDetallesPedidoUseCase';
import { UpdateDetallePedidoUseCase } from '../../domain/usecases/detallePedido/UpdateDetallePedidoUseCase';
import { DeletePedidoUseCase } from '../../domain/usecases/pedido/DeletePedidoUseCase';

import { clsPedido } from '../../domain/entities/clsPedido';
import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class UpdatePedidosProveedoresVM {

  pedido = signal<clsPedido | null>(null);
  detalles = signal<clsDetallePedido[]>([]);
  loading = signal(true);
  saving = signal(false);

  constructor(
    private getPedidoUC: GetPedidosUseCase,
    private getDetallesUC: GetDetallesPedidoUseCase,
    private updateDetalleUC: UpdateDetallePedidoUseCase,
    private deletePedidoUC: DeletePedidoUseCase
  ) {}

  async cargarDatos(idPedido: number) {
    this.loading.set(true);

    const p = await this.getPedidoUC.getPedidoPorId(idPedido);
    const dets = await this.getDetallesUC.getListaDetallesPorPedido(idPedido);

    this.pedido.set(p);
    this.detalles.set(dets);

    this.loading.set(false);
  }

  async guardarDetalles() {
    this.saving.set(true);

    try {
      for (const d of this.detalles()) {
        await this.updateDetalleUC.actualizarDetallePedido(
          d.IdPedido,
          d.IdProducto,
          d
        );
      }

      return true;

    } finally {
      this.saving.set(false);
    }
  }

  async eliminarPedidoDesdeDetalle(index: number) {
    const detalle = this.detalles()[index];

    await this.deletePedidoUC.eliminarPedido(detalle.IdPedido);

    this.pedido.set(null);
    this.detalles.set([]);
    return true;
  }
}
