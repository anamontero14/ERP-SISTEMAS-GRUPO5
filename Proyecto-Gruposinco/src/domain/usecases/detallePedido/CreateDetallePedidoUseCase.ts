
import { Injectable } from '@angular/core';
import { DetallesPedidoRepository } from '../../../data/repositories/DetallesPedidoRepository';
import { clsDetallePedido } from '../../entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class CreateDetallePedidoUseCase {
  constructor(private detallesPedidoRepository: DetallesPedidoRepository) {}

  async crearDetallePedido(detallePedidoNuevo: clsDetallePedido): Promise<number> {
    return await this.detallesPedidoRepository.crearDetallePedido(detallePedidoNuevo);
  }
}
