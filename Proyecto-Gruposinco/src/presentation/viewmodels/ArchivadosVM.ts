import { Injectable, signal } from '@angular/core';
import { PedidoRepository } from '../../data/repositories/PedidoRepository';
import { clsPedido } from '../../domain/entities/clsPedido';

@Injectable({ providedIn: 'root' })
export class ArchivadosVM {
  archivados = signal<clsPedido[]>([]);
  loading = signal<boolean>(false);
  error = signal<string | null>(null);

  constructor(private pedidoRepo: PedidoRepository) {}

  async cargarArchivados() {
    this.loading.set(true);
    this.error.set(null);
    try {
      const todos = await this.pedidoRepo.getListaPedidos();
      this.archivados.set(todos.filter(p => p.Archivado));
    } catch (e: any) {
      this.error.set('No se pudieron cargar los pedidos archivados. Inténtalo de nuevo.');
    } finally {
      this.loading.set(false);
    }
  }
}