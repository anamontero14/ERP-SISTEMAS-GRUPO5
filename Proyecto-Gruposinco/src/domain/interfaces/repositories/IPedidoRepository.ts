import { clsPedido } from '../../entities/clsPedido';
import { CrearPedidoDto } from '../../dtos/CrearPedidoDto';

export interface IPedidoRepository {
  getListaPedidos(): Promise<clsPedido[]>;
  getListaPedidosPorUsuario(idUsuario: number): Promise<clsPedido[]>;
  getListaPedidosPorProveedor(idProveedor: number): Promise<clsPedido[]>;
  getPedidoPorId(idPedido: number): Promise<clsPedido>;
  crearPedido(dto: CrearPedidoDto): Promise<number>
  actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number>;
  cambiarEstadoPedido(idPedido: number, nuevoEstado: string): Promise<number>;
  eliminarPedido(idPedido: number): Promise<number>;
}
