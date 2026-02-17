import { IPedidoRepository } from '../../interfaces/repositories/IPedidoRepository';
import { clsPedido } from '../../entities/clsPedido';
import { IGetPedidosUseCase } from '../../interfaces/usecases/Pedido/IGetPedidosUseCase';

export class GetPedidosUseCase implements IGetPedidosUseCase {
  constructor(private pedidoRepository: IPedidoRepository) {}

  async getListaPedidos(): Promise<clsPedido[]> {
    return await this.pedidoRepository.getListaPedidos();
  }

  async getListaPedidosPorUsuario(idUsuario: number): Promise<clsPedido[]> {
    return await this.pedidoRepository.getListaPedidosPorUsuario(idUsuario);
  }

  async getListaPedidosPorProveedor(idProveedor: number): Promise<clsPedido[]> {
    return await this.pedidoRepository.getListaPedidosPorProveedor(idProveedor);
  }

  async getPedidoPorId(idPedido: number): Promise<clsPedido> {
    return await this.pedidoRepository.getPedidoPorId(idPedido);
  }
}
