import { clsProveedor } from '../../../entities/clsProveedor';

export interface IGetProveedoresUseCase {
  getListaProveedores(): Promise<clsProveedor[]>;
  getProveedorPorId(idProveedor: number): Promise<clsProveedor>;
}
