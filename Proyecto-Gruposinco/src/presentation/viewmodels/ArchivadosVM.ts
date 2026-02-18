import { Injectable, signal } from '@angular/core';
import { PedidoRepository } from '../../data/repositories/PedidoRepository';
import { clsPedido } from '../../domain/entities/clsPedido';

@Injectable({ providedIn: 'root' })
export class ArchivadosVM {
  archivados = signal<clsPedido[]>([]);
  loading = signal<boolean>(false);

  constructor(private pedidoRepo: PedidoRepository) {}

  async cargarArchivados() {
    this.loading.set(true);
    try {
      const todos = await this.pedidoRepo.getListaPedidos();
      this.archivados.set(todos);
    } finally {
      this.loading.set(false);
    }
  }
}
