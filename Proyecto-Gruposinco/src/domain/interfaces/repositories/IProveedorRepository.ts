import { clsProveedor } from '../../entities/clsProveedor';

export interface IProveedorRepository {
  getListaProveedores(): Promise<clsProveedor[]>;
  getProveedorPorId(idProveedor: number): Promise<clsProveedor>;
}
