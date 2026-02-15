import { clsDetallePedido } from '../../../entities/clsDetallePedido';

export interface ICreateDetallePedidoUseCase {
  crearDetallePedido(detallePedidoNuevo: clsDetallePedido): Promise<number>;
}
