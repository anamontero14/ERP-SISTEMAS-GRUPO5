import { clsDetallePedido } from '../../../entities/clsDetallePedido';

export interface IUpdateDetallePedidoUseCase {
  actualizarDetallePedido(idPedido: number, idProducto: number, detallePedido: clsDetallePedido): Promise<number>;
}
