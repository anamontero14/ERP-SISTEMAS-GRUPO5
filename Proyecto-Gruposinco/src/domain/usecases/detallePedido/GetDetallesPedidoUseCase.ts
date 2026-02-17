
import { Injectable } from '@angular/core';
import { DetallesPedidoRepository } from '../../../data/repositories/DetallesPedidoRepository';
import { clsDetallePedido } from '../../entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class GetDetallesPedidoUseCase {
  constructor(private detallesPedidoRepository: DetallesPedidoRepository) {}

  async getListaDetallesPorPedido(idPedido: number): Promise<clsDetallePedido[]> {
    return await this.detallesPedidoRepository.getListaDetallesPorPedido(idPedido);
  }

  async getDetallePedidoPorId(idPedido: number, idProducto: number): Promise<clsDetallePedido> {
    return await this.detallesPedidoRepository.getDetallePedidoPorId(idPedido, idProducto);
  }
}
