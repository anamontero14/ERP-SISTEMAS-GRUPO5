import { IProveedorRepository } from '../../interfaces/repositories/IProveedorRepository';
import { clsProveedor } from '../../entities/clsProveedor';
import { IGetProveedoresUseCase } from '../../interfaces/usecases/proveedor/IGetProveedoresUseCase';

export class GetProveedoresUseCase implements IGetProveedoresUseCase {
  constructor(private proveedorRepository: IProveedorRepository) {}

  async getListaProveedores(): Promise<clsProveedor[]> {
    return await this.proveedorRepository.getListaProveedores();
  }

  async getProveedorPorId(idProveedor: number): Promise<clsProveedor> {
    return await this.proveedorRepository.getProveedorPorId(idProveedor);
  }
}
