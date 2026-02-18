import { Injectable } from '@angular/core';
import { clsPedido } from '../../domain/entities/clsPedido';
import { IPedidoRepository } from '../../domain/interfaces/repositories/IPedidoRepository';
import { ApiConnection } from '../datasource/api/ApiConnection';

@Injectable({
  providedIn: 'root'
})
export class PedidoRepository implements IPedidoRepository {

  constructor(private api: ApiConnection) {}

  // Mapper
  private mapToEntity(data: any): clsPedido {
    return new clsPedido(
      data.idPedido,
      data.idUsuario,
      data.idProveedor,
      new Date(data.fechaPedido),
      data.estado,
      data.observaciones ?? "",
      data.archivado ?? false
    );
  }

  // GET listado pedidos
  async getListaPedidos(): Promise<clsPedido[]> {
    const response = await this.api.getPedidos<any[]>();

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return response.data.map(d => this.mapToEntity(d));
  }

  // GET pedidos por usuario
  async getListaPedidosPorUsuario(idUsuario: number): Promise<clsPedido[]> {
    const response = await this.api.getPedidosPorUsuario<any[]>(idUsuario);

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return response.data.map(d => this.mapToEntity(d));
  }

  // GET por proveedor
  async getListaPedidosPorProveedor(idProveedor: number): Promise<clsPedido[]> {
    const pedidos = await this.getListaPedidos();
    return pedidos.filter(p => p.IdProveedor === idProveedor);
  }

  // GET por id
  async getPedidoPorId(idPedido: number): Promise<clsPedido> {
    const response = await this.api.getPedidoPorId<any>(idPedido);

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return this.mapToEntity(response.data);
  }

  // CREATE
  async crearPedido(pedido: clsPedido): Promise<number> {
    const response = await this.api.crearPedido<number>({
      idUsuario: pedido.IdUsuario,
      idProveedor: pedido.IdProveedor,
      fechaPedido: pedido.FechaPedido,
      estado: pedido.Estado,
      observaciones: pedido.Observaciones,
      archivado: pedido.Archivado
    });

    return response.success ? 1 : 0;
  }

  // UPDATE
  async actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number> {
    const response = await this.api.actualizarPedido<number>(
      idPedido,
      {
        idUsuario: pedido.IdUsuario,
        idProveedor: pedido.IdProveedor,
        fechaPedido: pedido.FechaPedido,
        estado: pedido.Estado,
        observaciones: pedido.Observaciones,
        archivado: pedido.Archivado
      }
    );

    return response.success ? 1 : 0;
  }

  // UPDATE estado
  async cambiarEstadoPedido(
    idPedido: number,
    nuevoEstado: "pedido" | "en preparación" | "entregado"
  ): Promise<number> {

    const response = await this.api.actualizarPedido<number>(
      idPedido,
      { estado: nuevoEstado }
    );

    return response.success ? 1 : 0;
  }

  // DELETE
  async eliminarPedido(idPedido: number): Promise<number> {
    const response = await this.api.eliminarPedido<number>(idPedido);
    return response.success ? 1 : 0;
  }
}
