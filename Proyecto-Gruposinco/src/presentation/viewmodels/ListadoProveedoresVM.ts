import { Injectable, signal } from '@angular/core';
import { GetProveedoresUseCase } from '../../domain/usecases/proveedor/GetProveedoresUseCase';
import { clsProveedor } from '../../domain/entities/clsProveedor';

@Injectable({ providedIn: 'root' })
export class ListProveedoresVM {

  proveedores = signal<clsProveedor[]>([]);
  loading = signal(true);

  constructor(
    private getProveedoresUC: GetProveedoresUseCase
  ) {}

  async cargarProveedores() {
    this.loading.set(true);

    const lista = await this.getProveedoresUC.getListaProveedores();
    this.proveedores.set(lista);

    this.loading.set(false);
  }
}
