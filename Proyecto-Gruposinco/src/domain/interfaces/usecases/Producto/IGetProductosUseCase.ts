import { clsProducto } from '../../../entities/clsProducto';

export interface IGetProductosUseCase {
  getListaProductos(): Promise<clsProducto[]>;
  getProductoPorId(idProducto: number): Promise<clsProducto>;
}
