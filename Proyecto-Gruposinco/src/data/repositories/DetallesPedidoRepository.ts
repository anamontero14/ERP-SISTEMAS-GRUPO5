import { Injectable } from '@angular/core';
import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';
import { IDetallesPedidoRepository } from '../../domain/interfaces/repositories/IDetallesPedidoRepository';
import { ApiConnection } from '../datasource/api/ApiConnection';

@Injectable({
  providedIn: 'root'
})
export class DetallesPedidoRepository implements IDetallesPedidoRepository {

  constructor(private api: ApiConnection) {}

  // GET lista detalles por pedido
  async getListaDetallesPorPedido(idPedido: number): Promise<clsDetallePedido[]> {
    const response = await this.api.getDetallesPedido<any[]>(idPedido);

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return response.data.map(d =>
      new clsDetallePedido(
        d.idPedido,
        d.idProducto,
        d.cantidad,
        d.precioUnitario
      )
    );
  }

  // GET detalle por id
  async getDetallePedidoPorId(idPedido: number, idProducto: number): Promise<clsDetallePedido> {
    const lista = await this.getListaDetallesPorPedido(idPedido);

    const detalle = lista.find(d => d.IdProducto === idProducto);

    if (!detalle) {
      throw new Error(`Detalle no encontrado para Pedido ${idPedido} y Producto ${idProducto}`);
    }

    return detalle;
  }

  // CREATE
  async crearDetallePedido(detalle: clsDetallePedido): Promise<number> {
    const response = await this.api.crearDetallePedido<number>({
      idPedido: detalle.IdPedido,
      idProducto: detalle.IdProducto,
      cantidad: detalle.Cantidad,
      precioUnitario: detalle.PrecioUnitario
    });

    return response.success ? 1 : 0;
  }

  // UPDATE
  async actualizarDetallePedido(idPedido: number, idProducto: number, detalle: clsDetallePedido): Promise<number> {
    const response = await this.api.actualizarDetallePedido<number>(
      idPedido,
      idProducto,
      {
        cantidad: detalle.Cantidad,
        precioUnitario: detalle.PrecioUnitario
      }
    );

    return response.success ? 1 : 0;
  }

}
