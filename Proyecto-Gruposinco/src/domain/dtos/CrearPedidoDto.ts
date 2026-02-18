import { clsDetallePedido } from '../entities/clsDetallePedido';
import { clsPedido } from '../entities/clsPedido';

export interface CrearPedidoDto {
  pedido: clsPedido;
  detalles: clsDetallePedido[];
}