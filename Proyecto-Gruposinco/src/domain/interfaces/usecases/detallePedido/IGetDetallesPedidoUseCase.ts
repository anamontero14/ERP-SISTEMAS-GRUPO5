import { clsDetallePedido } from '../../../entities/clsDetallePedido';

export interface IGetDetallesPedidoUseCase {
  getListaDetallesPorPedido(idPedido: number): Promise<clsDetallePedido[]>;
  getDetallePedidoPorId(idPedido: number, idProducto: number): Promise<clsDetallePedido>;
}
