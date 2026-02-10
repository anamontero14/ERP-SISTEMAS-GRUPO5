import { clsDetallePedido } from '../../entities/clsDetallePedido';

export interface IDetallesPedidoRepository {
  getListaDetallesPorPedido(idPedido: number): Promise<clsDetallePedido[]>;
  getDetallePedidoPorId(idPedido: number, idProducto: number): Promise<clsDetallePedido>;
  crearDetallePedido(detallePedidoNuevo: clsDetallePedido): Promise<number>;
  actualizarDetallePedido(idPedido: number, idProducto: number, detallePedido: clsDetallePedido): Promise<number>;
  eliminarDetallePedido(idPedido: number, idProducto: number): Promise<number>;
}
