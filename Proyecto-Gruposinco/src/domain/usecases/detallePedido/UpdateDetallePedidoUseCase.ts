
import { Injectable } from '@angular/core';
import { DetallesPedidoRepository } from '../../../data/repositories/DetallesPedidoRepository';
import { clsDetallePedido } from '../../entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class UpdateDetallePedidoUseCase {
  constructor(private detallesPedidoRepository: DetallesPedidoRepository) {}

  async actualizarDetallePedido(idPedido: number, idProducto: number, detallePedido: clsDetallePedido): Promise<number> {
    return await this.detallesPedidoRepository.actualizarDetallePedido(idPedido, idProducto, detallePedido);
  }
}
