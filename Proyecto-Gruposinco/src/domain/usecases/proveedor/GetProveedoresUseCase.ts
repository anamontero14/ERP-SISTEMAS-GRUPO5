
import { Injectable } from '@angular/core';
import { ProveedorRepository } from '../../../data/repositories/ProveedorRepository';
import { clsProveedor } from '../../entities/clsProveedor';

@Injectable({ providedIn: 'root' })
export class GetProveedoresUseCase {
  constructor(private proveedorRepository: ProveedorRepository) {}

  async getListaProveedores(): Promise<clsProveedor[]> {
    return await this.proveedorRepository.getListaProveedores();
  }

  async getProveedorPorId(idProveedor: number): Promise<clsProveedor> {
    return await this.proveedorRepository.getProveedorPorId(idProveedor);
  }
}
