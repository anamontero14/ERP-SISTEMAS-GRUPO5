import { IDetallesPedidoRepository } from '../../interfaces/repositories/IDetallesPedidoRepository';
import { clsDetallePedido } from '../../entities/clsDetallePedido';
import { ICreateDetallePedidoUseCase } from '../../interfaces/usecases/detallePedido/ICreateDetallePedidoUseCase';

export class CreateDetallePedidoUseCase implements ICreateDetallePedidoUseCase {
  constructor(private detallesPedidoRepository: IDetallesPedidoRepository) {}

  async crearDetallePedido(detallePedidoNuevo: clsDetallePedido): Promise<number> {
    return await this.detallesPedidoRepository.crearDetallePedido(detallePedidoNuevo);
  }
}
