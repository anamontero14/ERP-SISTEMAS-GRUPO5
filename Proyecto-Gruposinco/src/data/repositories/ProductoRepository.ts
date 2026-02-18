import { Injectable } from '@angular/core';
import { clsProducto } from '../../domain/entities/clsProducto';
import { IProductoRepository } from '../../domain/interfaces/repositories/IProductoRepository';
import { ApiConnection } from '../datasource/api/ApiConnection';

@Injectable({
  providedIn: 'root'
})
export class ProductoRepository implements IProductoRepository {

  constructor(private api: ApiConnection) {}

  // Mapper
  private mapToEntity(data: any): clsProducto {
    return new clsProducto(
      data.idProducto,
      data.nombreProducto,
      data.descripcionProducto,
      data.precioProducto,
      data.stockProducto,
      data.procedenciaProducto
    );
  }

  // GET listado productos
  async getListaProductos(): Promise<clsProducto[]> {
    const response = await this.api.getProductos<any[]>();

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return response.data.map(d => this.mapToEntity(d));
  }

  // GET producto por id
  async getProductoPorId(idProducto: number): Promise<clsProducto> {
    const response = await this.api.getProductoPorId<any>(idProducto);

    if (!response.success || !response.data) {
      throw new Error(response.message);
    }

    return this.mapToEntity(response.data);
  }
}
