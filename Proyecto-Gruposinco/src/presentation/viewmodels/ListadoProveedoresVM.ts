import { Injectable, signal } from '@angular/core';
import { GetProveedoresUseCase } from '../../domain/usecases/proveedor/GetProveedoresUseCase';
import { clsProveedor } from '../../domain/entities/clsProveedor';

@Injectable({ providedIn: 'root' })
export class ListProveedoresVM {

  proveedores = signal<clsProveedor[]>([]);
  loading = signal(true);
  error = signal<string | null>(null);

  constructor(private getProveedoresUC: GetProveedoresUseCase) {}

  async cargarProveedores() {
    this.loading.set(true);
    this.error.set(null);
    try {
      const lista = await this.getProveedoresUC.getListaProveedores();
      this.proveedores.set(lista);
    } catch (e: any) {
      this.error.set('No se pudieron cargar los proveedores. Inténtalo de nuevo.');
    } finally {
      this.loading.set(false);
    }
  }
}