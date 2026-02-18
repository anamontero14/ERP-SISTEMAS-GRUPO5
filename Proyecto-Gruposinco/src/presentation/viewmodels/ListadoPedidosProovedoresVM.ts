import { Injectable, signal } from '@angular/core';
import { GetPedidosUseCase } from '../../domain/usecases/pedido/GetPedidosUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';

@Injectable({ providedIn: 'root' })
export class ListadoPedidosProveedoresVM {
  pedidos = signal<clsPedido[]>([]);
  loading = signal<boolean>(false);

  constructor(private getPedidosUC: GetPedidosUseCase) {}

  async cargarPedidos() {
    this.loading.set(true);
    try {
      const lista = await this.getPedidosUC.getListaPedidos();
      this.pedidos.set(lista.filter(p => !p.Archivado));
    } finally {
      this.loading.set(false);
    }
  }
}
