import { clsPedido } from '../../../entities/clsPedido';

export interface ICreatePedidoUseCase {
  crearPedido(pedidoNuevo: clsPedido): Promise<number>;
}
