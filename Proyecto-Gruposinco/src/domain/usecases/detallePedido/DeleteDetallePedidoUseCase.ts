
import { Injectable } from '@angular/core';
import { DetallesPedidoRepository } from '../../../data/repositories/DetallesPedidoRepository';

@Injectable({ providedIn: 'root' })
export class DeleteDetallePedidoUseCase {
  constructor(private detallesPedidoRepository: DetallesPedidoRepository) {}

  /*async eliminarDetallePedido(idPedido: number, idProducto: number): Promise<number> {
    return await this.detallesPedidoRepository.eliminarDetallePedido(idPedido, idProducto);
  }*/
}
