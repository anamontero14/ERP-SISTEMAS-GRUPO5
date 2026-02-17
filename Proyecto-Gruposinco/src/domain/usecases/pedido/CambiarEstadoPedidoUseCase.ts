
import { Injectable } from '@angular/core';
import { PedidoRepository } from '../../../data/repositories/PedidoRepository';

@Injectable({ providedIn: 'root' })
export class CambiarEstadoPedidoUseCase {
  constructor(private pedidoRepository: PedidoRepository) {}

  async cambiarEstadoPedido(idPedido: number, nuevoEstado: string): Promise<number> {
    const pedido = await this.pedidoRepository.getPedidoPorId(idPedido);
    // Si ya está entregado, no se puede cambiar
    if (pedido.Estado === 'entregado') {
      throw new Error('No se puede cambiar el estado de un pedido entregado.');
    }
    // Solo se permiten transiciones válidas
    if (pedido.Estado === 'pedido' && nuevoEstado === 'en preparación') {
      return await this.pedidoRepository.cambiarEstadoPedido(idPedido, nuevoEstado);
    }
    if (pedido.Estado === 'en preparación' && nuevoEstado === 'entregado') {
      return await this.pedidoRepository.cambiarEstadoPedido(idPedido, nuevoEstado);
    }
    throw new Error('Transición de estado no permitida.');
  }
}
