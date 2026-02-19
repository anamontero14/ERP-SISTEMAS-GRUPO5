import { Injectable, signal } from '@angular/core';
import { GetPedidosUseCase } from '../../domain/usecases/pedido/GetPedidosUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';

@Injectable({ providedIn: 'root' })
export class ListadoPedidosProveedoresVM {
  pedidos = signal<clsPedido[]>([]);
  loading = signal<boolean>(false);
  error = signal<string | null>(null); // 👈

  constructor(private getPedidosUC: GetPedidosUseCase) {}

  async cargarPedidos() {
    this.loading.set(true);
    this.error.set(null);
    try {
      const lista = await this.getPedidosUC.getListaPedidos();
      this.pedidos.set(lista.filter(p => !p.Archivado));
    } catch (e: any) {
      this.error.set('No se pudieron cargar los pedidos. Inténtalo de nuevo.'); // 👈
    } finally {
      this.loading.set(false);
    }
  }
}
