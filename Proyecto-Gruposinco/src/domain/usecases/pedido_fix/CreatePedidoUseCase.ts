import { Injectable } from '@angular/core';
import { PedidoRepository } from '../../../data/repositories/PedidoRepository';
import { CrearPedidoDto } from '../../dtos/CrearPedidoDto';
import { ICreatePedidoUseCase } from '../../interfaces/usecases/pedido_fix/ICreatePedidoUseCase';

@Injectable({ providedIn: 'root' })
export class CreatePedidoUseCase {
  constructor(private pedidoRepository: PedidoRepository) {}

  async crearPedido(pedidoNuevo: CrearPedidoDto): Promise<number> {
    return await this.pedidoRepository.crearPedido(pedidoNuevo);
  }
}