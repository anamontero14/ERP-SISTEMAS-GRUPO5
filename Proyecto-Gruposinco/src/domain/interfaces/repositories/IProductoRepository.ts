import { clsProducto } from '../../entities/clsProducto';

export interface IProductoRepository {
  getListaProductos(): Promise<clsProducto[]>;
  getProductoPorId(idProducto: number): Promise<clsProducto>;
}
