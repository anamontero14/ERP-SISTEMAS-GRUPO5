
import { Injectable } from '@angular/core';
import { PedidoRepository } from '../../../data/repositories/PedidoRepository';

@Injectable({ providedIn: 'root' })
export class DeletePedidoUseCase {
  constructor(private pedidoRepository: PedidoRepository) {}

  async eliminarPedido(idPedido: number): Promise<number> {
    return await this.pedidoRepository.eliminarPedido(idPedido);
  }
}
