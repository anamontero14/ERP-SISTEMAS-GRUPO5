import { IDetallesPedidoRepository } from '../../interfaces/repositories/IDetallesPedidoRepository';
import { IDeleteDetallePedidoUseCase } from '../../interfaces/usecases/detallePedido/IDeleteDetallePedidoUseCase';

export class DeleteDetallePedidoUseCase implements IDeleteDetallePedidoUseCase {
  constructor(private detallesPedidoRepository: IDetallesPedidoRepository) {}

  async eliminarDetallePedido(idPedido: number, idProducto: number): Promise<number> {
    return await this.detallesPedidoRepository.eliminarDetallePedido(idPedido, idProducto);
  }
}
