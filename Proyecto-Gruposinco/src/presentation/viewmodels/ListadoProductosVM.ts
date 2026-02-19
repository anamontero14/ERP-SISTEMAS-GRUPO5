import { Injectable, signal } from '@angular/core';
import { GetProductosUseCase } from '../../domain/usecases/producto/GetProductosUseCase';
import { clsProducto } from '../../domain/entities/clsProducto';

@Injectable({ providedIn: 'root' })
export class ListProductosVM {

  productos = signal<clsProducto[]>([]);
  loading = signal(true);
  error = signal<string | null>(null);

  constructor(private getProductosUC: GetProductosUseCase) {}

  async cargarProductos() {
    this.loading.set(true);
    this.error.set(null);
    try {
      const lista = await this.getProductosUC.getListaProductos();
      this.productos.set(lista);
    } catch (e: any) {
      this.error.set('No se pudieron cargar los productos. Inténtalo de nuevo.');
    } finally {
      this.loading.set(false);
    }
  }
}