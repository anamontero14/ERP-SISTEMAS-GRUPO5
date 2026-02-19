import { Injectable, signal } from '@angular/core';
import { CreatePedidoUseCase } from '../../domain/usecases/pedido_fix/CreatePedidoUseCase';
import { GetProveedoresUseCase } from '../../domain/usecases/proveedor/GetProveedoresUseCase';
import { GetProductosUseCase } from '../../domain/usecases/producto_fix/GetProductosUseCase';
import { CreateDetallePedidoUseCase } from '../../domain/usecases/detallePedido/CreateDetallePedidoUseCase';
import { clsPedido } from '../../domain/entities/clsPedido';
import { clsProveedor } from '../../domain/entities/clsProveedor';
import { clsProducto } from '../../domain/entities/clsProducto';
import { CrearPedidoDto } from '../../domain/dtos/CrearPedidoDto';
import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';

@Injectable({ providedIn: 'root' })
export class CreatePedidosProveedoresVM {

  proveedores = signal<clsProveedor[]>([]);
  productos = signal<clsProducto[]>([]);
  detalles = signal<clsDetallePedido[]>([]);
  saving = signal<boolean>(false);

  constructor(
    private createPedidoUC: CreatePedidoUseCase,
    private getProveedoresUC: GetProveedoresUseCase,
    private getProductosUC: GetProductosUseCase
  ) {}

  async cargarDatos() {
    this.proveedores.set(await this.getProveedoresUC.getListaProveedores());
    this.productos.set(await this.getProductosUC.getListaProductos());
  }

  agregarDetalle(idProducto: number, cantidad: number) {
    const producto = this.productos().find(p => p.IdProducto === idProducto);
    if (!producto) return;

    const detalle = new clsDetallePedido(
      0,
      idProducto,
      cantidad,
      producto.PrecioProducto
    );

    this.detalles.update(list => [...list, detalle]);
  }

  eliminarDetalle(index: number) {
    this.detalles.update(list => list.filter((_, i) => i !== index));
  }

  async crearPedidoCompleto(
    idUsuario: number,
    idProveedor: number,
    observaciones: string
  ) {
    this.saving.set(true);

    try {
      const dto: CrearPedidoDto = {
  pedido: new clsPedido(
    0,
    idUsuario,
    idProveedor,
    new Date(),
    "pedido",
    observaciones,
    false
  ),
  detalles: this.detalles().map(d =>
    new clsDetallePedido(
      0,
      d.IdProducto,
      d.Cantidad,
      d.PrecioUnitario
    )
  )
};


      return await this.createPedidoUC.crearPedido(dto);

    } finally {
      this.saving.set(false);
    }
  }
}
