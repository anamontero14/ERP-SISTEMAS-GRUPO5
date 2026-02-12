import { IDetallesPedidoRepository } from '../../interfaces/repositories/IDetallesPedidoRepository';
import { clsDetallePedido } from '../../entities/clsDetallePedido';
import { IGetDetallesPedidoUseCase } from '../../interfaces/usecases/detallePedido/IGetDetallesPedidoUseCase';

export class GetDetallesPedidoUseCase implements IGetDetallesPedidoUseCase {
  constructor(private detallesPedidoRepository: IDetallesPedidoRepository) {}

  async getListaDetallesPorPedido(idPedido: number): Promise<clsDetallePedido[]> {
    return await this.detallesPedidoRepository.getListaDetallesPorPedido(idPedido);
  }

  async getDetallePedidoPorId(idPedido: number, idProducto: number): Promise<clsDetallePedido> {
    return await this.detallesPedidoRepository.getDetallePedidoPorId(idPedido, idProducto);
  }
}
