import { IPedidoRepository } from '../../interfaces/repositories/IPedidoRepository';
import { clsPedido } from '../../entities/clsPedido';
import { IUpdatePedidoUseCase } from '../../interfaces/usecases/pedido/IUpdatePedidoUseCase';

export class UpdatePedidoUseCase implements IUpdatePedidoUseCase {
  constructor(private pedidoRepository: IPedidoRepository) {}

  async actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number> {
    return await this.pedidoRepository.actualizarPedido(idPedido, pedido);
  }
}
