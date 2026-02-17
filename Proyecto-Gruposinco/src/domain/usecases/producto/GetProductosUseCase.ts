import { IProductoRepository } from '../../interfaces/repositories/IProductoRepository';
import { clsProducto } from '../../entities/clsProducto';
import { IGetProductosUseCase } from '../../interfaces/usecases/producto/IGetProductosUseCase';

export class GetProductosUseCase implements IGetProductosUseCase {
  constructor(private productoRepository: IProductoRepository) {}

  async getListaProductos(): Promise<clsProducto[]> {
    return await this.productoRepository.getListaProductos();
  }

  async getProductoPorId(idProducto: number): Promise<clsProducto> {
    return await this.productoRepository.getProductoPorId(idProducto);
  }
}
