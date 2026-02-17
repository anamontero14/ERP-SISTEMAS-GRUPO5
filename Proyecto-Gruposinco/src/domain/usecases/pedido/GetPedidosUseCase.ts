
import { Injectable } from '@angular/core';
import { PedidoRepository } from '../../../data/repositories/PedidoRepository';
import { clsPedido } from '../../entities/clsPedido';
import { IGetPedidosUseCase } from '../../interfaces/usecases/Pedido/IGetPedidosUseCase';

@Injectable({ providedIn: 'root' })
export class GetPedidosUseCase {
  constructor(private pedidoRepository: PedidoRepository) {}

  async getListaPedidos(): Promise<clsPedido[]> {
    return await this.pedidoRepository.getListaPedidos();
  }

  async getListaPedidosPorUsuario(idUsuario: number): Promise<clsPedido[]> {
    return await this.pedidoRepository.getListaPedidosPorUsuario(idUsuario);
  }

  async getListaPedidosPorProveedor(idProveedor: number): Promise<clsPedido[]> {
    return await this.pedidoRepository.getListaPedidosPorProveedor(idProveedor);
  }

  async getPedidoPorId(idPedido: number): Promise<clsPedido> {
    return await this.pedidoRepository.getPedidoPorId(idPedido);
  }
}
