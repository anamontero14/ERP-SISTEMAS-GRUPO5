import { clsProveedor } from '../../../entities/clsProveedor';

export interface IGetProveedorUseCase {
  getListaProveedores(): Promise<clsProveedor[]>;
  getProveedorPorId(idProveedor: number): Promise<clsProveedor>;
}
