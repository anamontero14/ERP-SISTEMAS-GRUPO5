import { Container } from "inversify";
import { TYPES } from "./types";

// DataSources
import { ApiConnection } from "../data/datasource/api/ApiConnection";

// Repositories
import { ProductoRepository } from "../data/repositories/ProductoRepository";
import { ProveedorRepository } from "../data/repositories/ProveedorRepository";
import { PedidoRepository } from "../data/repositories/PedidoRepository";
import { UsuarioRepository } from "../data/repositories/UsuarioRepository";
import { DetallesPedidoRepository } from "../data/repositories/DetallesPedidoRepository";

import { IProductoRepository } from "../domain/interfaces/repositories/IProductoRepository";
import { IProveedorRepository } from "../domain/interfaces/repositories/IProveedorRepository";
import { IPedidoRepository } from "../domain/interfaces/repositories/IPedidoRepository";
import { IUsuarioRepository } from "../domain/interfaces/repositories/IUsuarioRepository";
import { IDetallesPedidoRepository } from "../domain/interfaces/repositories/IDetallesPedidoRepository";

// UseCases
import { IGetProductosUseCase } from "../domain/interfaces/usecases/producto_fix/IGetProductosUseCase";
import { IGetProveedoresUseCase } from "../domain/interfaces/usecases/proveedor/IGetProveedoresUseCase";

import { IGetPedidosUseCase } from "../domain/interfaces/usecases/pedido_fix/IGetPedidosUseCase";
import { ICreatePedidoUseCase } from "../domain/interfaces/usecases/pedido_fix/ICreatePedidoUseCase";
import { IUpdatePedidoUseCase } from "../domain/interfaces/usecases/pedido_fix/IUpdatePedidoUseCase";
import { ICambiarEstadoPedidoUseCase } from "../domain/interfaces/usecases/pedido_fix/ICambiarEstadoPedidoUseCase";
import { IDeletePedidoUseCase } from "../domain/interfaces/usecases/pedido_fix/IDeletePedidoUseCase";

import { IGetDetallesPedidoUseCase } from "../domain/interfaces/usecases/detallePedido/IGetDetallesPedidoUseCase";
import { ICreateDetallePedidoUseCase } from "../domain/interfaces/usecases/detallePedido/ICreateDetallePedidoUseCase";
import { IUpdateDetallePedidoUseCase } from "../domain/interfaces/usecases/detallePedido/IUpdateDetallePedidoUseCase";
import { IDeleteDetallePedidoUseCase } from "../domain/interfaces/usecases/detallePedido/IDeleteDetallePedidoUseCase";


import { GetProductosUseCase } from "../domain/usecases/producto_fix/GetProductosUseCase";
import { GetProveedoresUseCase } from "../domain/usecases/proveedor/GetProveedoresUseCase";

import { GetPedidosUseCase } from "../domain/usecases/pedido_fix/GetPedidosUseCase";
import { CreatePedidoUseCase } from "../domain/usecases/pedido_fix/CreatePedidoUseCase";
import { UpdatePedidoUseCase } from "../domain/usecases/pedido_fix/UpdatePedidoUseCase";
import { CambiarEstadoPedidoUseCase } from "../domain/usecases/pedido_fix/CambiarEstadoPedidoUseCase";
import { DeletePedidoUseCase } from "../domain/usecases/pedido_fix/DeletePedidoUseCase";

import { GetDetallesPedidoUseCase } from "../domain/usecases/detallePedido/GetDetallesPedidoUseCase";
import { CreateDetallePedidoUseCase } from "../domain/usecases/detallePedido/CreateDetallePedidoUseCase";
import { UpdateDetallePedidoUseCase } from "../domain/usecases/detallePedido/UpdateDetallePedidoUseCase";
import { DeleteDetallePedidoUseCase } from "../domain/usecases/detallePedido/DeleteDetallePedidoUseCase";

// Viewmodels
/**
 * import { LoginVM } from "../presentation/viewmodels/LoginVM";
 * import { ListadoPedidosProveedoresVM } from "../presentation/viewmodels/ListadoPedidosProveedoresVM";
 * import { CreatePedidosProveedoresVM } from "../presentation/viewmodels/CreatePedidosProveedoresVM";
 * import { DetailsPedidosProveedoresVM } from "../presentation/viewmodels/DetailsPedidosProveedoresVM";
 * import { UpdatePedidosProveedoresVM } from "../presentation/viewmodels/UpdatePedidosProveedoresVM";
 * import { ArchivadosVM } from "../presentation/viewmodels/ArchivadosVM";
 */

const container = new Container();

// Bind DataSources
container.bind<ApiConnection>(TYPES.ApiConnection)
  .to(ApiConnection)
  .inSingletonScope();

// Bind Repositories
container.bind<IProductoRepository>(TYPES.IProductoRepository)
  .to(ProductoRepository);

container.bind<IProveedorRepository>(TYPES.IProveedorRepository)
  .to(ProveedorRepository);

container.bind<IPedidoRepository>(TYPES.IPedidoRepository)
  .to(PedidoRepository);

container.bind<IUsuarioRepository>(TYPES.IUsuarioRepository)
  .to(UsuarioRepository);

container.bind<IDetallesPedidoRepository>(TYPES.IDetallesPedidoRepository)
  .to(DetallesPedidoRepository);

// Bind UseCases
container.bind<IGetProductosUseCase>(TYPES.IGetProductosUseCase)
  .to(GetProductosUseCase);

container.bind<IGetProveedoresUseCase>(TYPES.IGetProveedoresUseCase)
  .to(GetProveedoresUseCase);

container.bind<IGetPedidosUseCase>(TYPES.IGetPedidosUseCase)
  .to(GetPedidosUseCase);
container.bind<ICreatePedidoUseCase>(TYPES.ICreatePedidoUseCase)
  .to(CreatePedidoUseCase);
container.bind<IUpdatePedidoUseCase>(TYPES.IUpdatePedidoUseCase)
  .to(UpdatePedidoUseCase);
container.bind<ICambiarEstadoPedidoUseCase>(TYPES.ICambiarEstadoPedidoUseCase)
  .to(CambiarEstadoPedidoUseCase);
container.bind<IDeletePedidoUseCase>(TYPES.IDeletePedidoUseCase)
  .to(DeletePedidoUseCase);

container.bind<IGetDetallesPedidoUseCase>(TYPES.IGetDetallesPedidoUseCase)
  .to(GetDetallesPedidoUseCase);
container.bind<ICreateDetallePedidoUseCase>(TYPES.ICreateDetallePedidoUseCase)
  .to(CreateDetallePedidoUseCase);
container.bind<IUpdateDetallePedidoUseCase>(TYPES.IUpdateDetallePedidoUseCase)
  .to(UpdateDetallePedidoUseCase);
/*container.bind<IDeleteDetallePedidoUseCase>(TYPES.IDeleteDetallePedidoUseCase)
  .to(DeleteDetallePedidoUseCase);*/


// Bind Viewmodels
/**
 * container.bind(TYPES.LoginVM)
 * .to(LoginVM)
 * .inSingletonScope();
 *
 * container.bind(TYPES.ListadoPedidosProveedoresVM)
 * .to(ListadoPedidosProveedoresVM)
 * .inSingletonScope();
 *
 * container.bind(TYPES.CreatePedidosProveedoresVM)
 * .to(CreatePedidosProveedoresVM)
 * .inSingletonScope();
 *
 * container.bind(TYPES.DetailsPedidosProveedoresVM)
 * .to(DetailsPedidosProveedoresVM)
 * .inSingletonScope();
 *
 * container.bind(TYPES.UpdatePedidosProveedoresVM)
 * .to(UpdatePedidosProveedoresVM)
 * .inSingletonScope();
 *
 * container.bind(TYPES.ArchivadosVM)
 * .to(ArchivadosVM)
 * .inSingletonScope();
 */

export { container };
