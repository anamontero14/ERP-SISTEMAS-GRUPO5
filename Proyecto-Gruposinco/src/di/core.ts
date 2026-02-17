import { IUsuarioRepository, IProductoRepository, IProveedorRepository, IPedidoRepository, IDetallesPedidoRepository } from "./types";
import { UsuarioRepository } from "../data/repositories/UsuarioRepository";
import { ProductoRepository } from "../data/repositories/ProductoRepository";
import { ProveedorRepository } from "../data/repositories/ProveedorRepository";
import { PedidoRepository } from "../data/repositories/PedidoRepository";
import { DetallesPedidoRepository } from "../data/repositories/DetallesPedidoRepository";

// Singleton container
export class Container {
  private static _instance: Container;

  // ANA
  // usuarioRepository: IUsuarioRepository;
  productoRepository: IProductoRepository;
  proveedorRepository: IProveedorRepository;
  pedidoRepository: IPedidoRepository;
  detallesPedidoRepository: IDetallesPedidoRepository;

  private constructor() {
    // ANA
    // this.usuarioRepository = new UsuarioRepository();
    this.productoRepository = new ProductoRepository();
    this.proveedorRepository = new ProveedorRepository();
    this.pedidoRepository = new PedidoRepository();
    this.detallesPedidoRepository = new DetallesPedidoRepository();
  }

  public static getInstance(): Container {
    if (!Container._instance) {
      Container._instance = new Container();
    }
    return Container._instance;
  }
}