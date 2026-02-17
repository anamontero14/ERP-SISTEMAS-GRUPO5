
import { Injectable } from '@angular/core';
import { ProductoRepository } from '../../../data/repositories/ProductoRepository';
import { clsProducto } from '../../entities/clsProducto';

@Injectable({ providedIn: 'root' })
export class GetProductosUseCase {
  constructor(private productoRepository: ProductoRepository) {}

  async getListaProductos(): Promise<clsProducto[]> {
    return await this.productoRepository.getListaProductos();
  }

  async getProductoPorId(idProducto: number): Promise<clsProducto> {
    return await this.productoRepository.getProductoPorId(idProducto);
  }
}
