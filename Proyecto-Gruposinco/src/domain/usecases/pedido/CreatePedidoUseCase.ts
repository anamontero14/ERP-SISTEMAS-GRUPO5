import { IPedidoRepository } from '../../interfaces/repositories/IPedidoRepository';
import { clsPedido } from '../../entities/clsPedido';
import { ICreatePedidoUseCase } from '../../interfaces/usecases/Pedido/ICreatePedidoUseCase';

export class CreatePedidoUseCase implements ICreatePedidoUseCase {
  constructor(private pedidoRepository: IPedidoRepository) {}

  async crearPedido(pedidoNuevo: clsPedido): Promise<number> {
    return await this.pedidoRepository.crearPedido(pedidoNuevo);
  }
}
