import { Injectable, signal } from '@angular/core';
import { GetPedidosUseCase } from '../../domain/usecases/pedido/GetPedidosUseCase';
import { GetDetallesPedidoUseCase } from '../../domain/usecases/detallePedido/GetDetallesPedidoUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';
import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class DetailsPedidosProveedoresVM {

  loading = signal(true);
  error = signal<string | null>(null);
  pedido = signal<clsPedido | null>(null);
  detalles = signal<clsDetallePedido[]>([]);

  constructor(
    private getPedidoUC: GetPedidosUseCase,
    private getDetallesUC: GetDetallesPedidoUseCase
  ) {}

  async cargarDatos(idPedido: number) {
    this.loading.set(true);
    this.error.set(null);
    try {
      const p = await this.getPedidoUC.getPedidoPorId(idPedido);
      const d = await this.getDetallesUC.getListaDetallesPorPedido(idPedido);
      this.pedido.set(p);
      this.detalles.set(d);
    } catch (e: any) {
      this.error.set('No se pudieron cargar los datos del pedido. Inténtalo de nuevo.');
    } finally {
      this.loading.set(false);
    }
  }
}