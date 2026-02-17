
import { Injectable } from '@angular/core';
import { PedidoRepository } from '../../../data/repositories/PedidoRepository';
import { clsPedido } from '../../entities/clsPedido';

@Injectable({ providedIn: 'root' })
export class CreatePedidoUseCase {
  constructor(private pedidoRepository: PedidoRepository) {}

  async crearPedido(pedidoNuevo: clsPedido): Promise<number> {
    return await this.pedidoRepository.crearPedido(pedidoNuevo);
  }
}
