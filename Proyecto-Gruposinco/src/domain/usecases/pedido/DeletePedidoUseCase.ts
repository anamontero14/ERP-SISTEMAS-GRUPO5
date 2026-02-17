import { IPedidoRepository } from '../../interfaces/repositories/IPedidoRepository';
import { IDeletePedidoUseCase } from '../../interfaces/usecases/Pedido/IDeletePedidoUseCase';

export class DeletePedidoUseCase implements IDeletePedidoUseCase {
  constructor(private pedidoRepository: IPedidoRepository) {}

  async eliminarPedido(idPedido: number): Promise<number> {
    return await this.pedidoRepository.eliminarPedido(idPedido);
  }
}
