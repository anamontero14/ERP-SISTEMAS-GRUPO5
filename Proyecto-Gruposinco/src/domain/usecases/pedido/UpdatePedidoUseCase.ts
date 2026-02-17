
import { Injectable } from '@angular/core';
import { PedidoRepository } from '../../../data/repositories/PedidoRepository';
import { clsPedido } from '../../entities/clsPedido';

@Injectable({ providedIn: 'root' })
export class UpdatePedidoUseCase {
  constructor(private pedidoRepository: PedidoRepository) {}

  async actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number> {
    return await this.pedidoRepository.actualizarPedido(idPedido, pedido);
  }
}
