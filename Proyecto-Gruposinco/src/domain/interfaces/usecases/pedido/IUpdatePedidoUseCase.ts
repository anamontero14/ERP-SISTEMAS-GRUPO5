import { clsPedido } from '../../../entities/clsPedido';

export interface IUpdatePedidoUseCase {
  actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number>;
}
