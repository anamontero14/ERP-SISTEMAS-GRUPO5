import { IDetallesPedidoRepository } from '../../interfaces/repositories/IDetallesPedidoRepository';
import { clsDetallePedido } from '../../entities/clsDetallePedido';
import { IUpdateDetallePedidoUseCase } from '../../interfaces/usecases/detallePedido/IUpdateDetallePedidoUseCase';

export class UpdateDetallePedidoUseCase implements IUpdateDetallePedidoUseCase {
  constructor(private detallesPedidoRepository: IDetallesPedidoRepository) {}

  async actualizarDetallePedido(idPedido: number, idProducto: number, detallePedido: clsDetallePedido): Promise<number> {
    return await this.detallesPedidoRepository.actualizarDetallePedido(idPedido, idProducto, detallePedido);
  }
}
