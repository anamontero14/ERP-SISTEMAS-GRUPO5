import { Injectable, signal } from '@angular/core';
import { GetProductosUseCase } from '../../domain/usecases/producto_fix/GetProductosUseCase';
import { clsProducto } from '../../domain/entities/clsProducto';

@Injectable({ providedIn: 'root' })
export class ListProductosVM {

  productos = signal<clsProducto[]>([]);
  loading = signal(true);

  constructor(private getProductosUC: GetProductosUseCase) {}

  async cargarProductos() {
    this.loading.set(true);

    const lista = await this.getProductosUC.getListaProductos();
    this.productos.set(lista);

    this.loading.set(false);
  }
}
