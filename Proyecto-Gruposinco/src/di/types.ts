import { clsUsuario } from "../domain/entities/clsUsuario";
import { clsProducto } from "../domain/entities/clsProducto";
import { clsProveedor } from "../domain/entities/clsProveedor";
import { clsPedido } from "../domain/entities/clsPedido";
import { clsDetallePedido } from "../domain/entities/clsDetallePedido";

// Interfaces de repositorios
export interface IUsuarioRepository {
  getListaUsuarios(): Promise<clsUsuario[]>;
  getUsuarioPorId(idUsuario: number): Promise<clsUsuario>;
  getUsuarioPorNombre(nombre: string): Promise<clsUsuario>;
  crearUsuario(usuarioNuevo: clsUsuario): Promise<number>;
  actualizarUsuario(idUsuario: number, usuario: clsUsuario): Promise<number>;
  eliminarUsuario(idUsuario: number): Promise<number>;
}

export interface IProductoRepository {
  getListaProductos(): Promise<clsProducto[]>;
  getProductoPorId(idProducto: number): Promise<clsProducto>;
}

export interface IProveedorRepository {
  getListaProveedores(): Promise<clsProveedor[]>;
  getProveedorPorId(idProveedor: number): Promise<clsProveedor>;
}

export interface IPedidoRepository {
  getListaPedidos(): Promise<clsPedido[]>;
  getListaPedidosPorUsuario(idUsuario: number): Promise<clsPedido[]>;
  getListaPedidosPorProveedor(idProveedor: number): Promise<clsPedido[]>;
  getPedidoPorId(idPedido: number): Promise<clsPedido>;
  crearPedido(pedidoNuevo: clsPedido): Promise<number>;
  actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number>;
  cambiarEstadoPedido(idPedido: number, nuevoEstado: string): Promise<number>;
  eliminarPedido(idPedido: number): Promise<number>;
}

export interface IDetallesPedidoRepository {
  getListaDetallesPorPedido(idPedido: number): Promise<clsDetallePedido[]>;
  getDetallePedidoPorId(idPedido: number, idProducto: number): Promise<clsDetallePedido>;
  crearDetallePedido(detallePedidoNuevo: clsDetallePedido): Promise<number>;
  actualizarDetallePedido(idPedido: number, idProducto: number, detallePedido: clsDetallePedido): Promise<number>;
  eliminarDetallePedido(idPedido: number, idProducto: number): Promise<number>;
}