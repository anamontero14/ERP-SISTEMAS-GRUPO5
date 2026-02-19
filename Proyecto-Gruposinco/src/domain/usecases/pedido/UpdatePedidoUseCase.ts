
import { Injectable } from '@angular/core';
import { PedidoRepository } from '../../../data/repositories/PedidoRepository';
import { clsPedido } from '../../entities/clsPedido';
import { IUpdatePedidoUseCase } from '../../interfaces/usecases/pedido/IUpdatePedidoUseCase';

@Injectable({ providedIn: 'root' })
export class UpdatePedidoUseCase {
  constructor(private pedidoRepository: PedidoRepository) {}

  async actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number> {
    return await this.pedidoRepository.actualizarPedido(idPedido, pedido);
  }
}
