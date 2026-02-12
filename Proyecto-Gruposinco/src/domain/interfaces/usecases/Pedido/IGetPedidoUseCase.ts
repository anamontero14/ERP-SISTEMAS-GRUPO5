import { clsPedido } from '../../../entities/clsPedido';

export interface IGetPedidoUseCase {
  getListaPedidos(): Promise<clsPedido[]>;
  getListaPedidosPorUsuario(idUsuario: number): Promise<clsPedido[]>;
  getListaPedidosPorProveedor(idProveedor: number): Promise<clsPedido[]>;
  getPedidoPorId(idPedido: number): Promise<clsPedido>;
}
