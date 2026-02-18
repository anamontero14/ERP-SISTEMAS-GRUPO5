import { Injectable, signal } from '@angular/core';
import { CreatePedidoUseCase } from '../../domain/usecases/pedido/CreatePedidoUseCase';
import { GetProveedoresUseCase } from '../../domain/usecases/proveedor/GetProveedoresUseCase';
import { GetProductosUseCase } from '../../domain/usecases/producto/GetProductosUseCase';
import { CreateDetallePedidoUseCase } from '../../domain/usecases/detallePedido/CreateDetallePedidoUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';
import { clsProveedor } from '../../domain/entities/clsProveedor';
import { clsProducto } from '../../domain/entities/clsProducto';
import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class CreatePedidosProveedoresVM {

  proveedores = signal<clsProveedor[]>([]);
  productos = signal<clsProducto[]>([]);
  saving = signal<boolean>(false);

  constructor(
    private createPedidoUC: CreatePedidoUseCase,
    private getProveedoresUC: GetProveedoresUseCase,
    private getProductosUC: GetProductosUseCase,
    private createDetalleUC: CreateDetallePedidoUseCase
  ) {}

  async cargarDatos() {
    this.proveedores.set(await this.getProveedoresUC.getListaProveedores());
    this.productos.set(await this.getProductosUC.getListaProductos());
  }

  async crearPedidoConDetalle(
    pedido: clsPedido,
    idProducto: number,
    cantidad: number
  ) {
    this.saving.set(true);
    try {
      const idPedido = await this.createPedidoUC.crearPedido(pedido);

      // Obtener el producto para sacar su precio
      const producto = this.productos().find(p => p.IdProducto === idProducto);
      const precioUnitario = producto?.PrecioProducto ?? 0;

      const detalle = new clsDetallePedido(
        idPedido,
        idProducto,
        cantidad,
        precioUnitario
      );

      await this.createDetalleUC.crearDetallePedido(detalle);

      return idPedido;
    } finally {
      this.saving.set(false);
    }
  }
}
