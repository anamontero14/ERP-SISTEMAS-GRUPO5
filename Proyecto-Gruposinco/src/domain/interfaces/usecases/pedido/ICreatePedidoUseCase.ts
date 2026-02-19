import { CrearPedidoDto } from '../../../dtos/CrearPedidoDto';

export interface ICreatePedidoUseCase {
  crearPedido(pedidoNuevo: CrearPedidoDto): Promise<number>;
}
