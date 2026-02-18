export const TYPES = {

  // DataSources
  ApiConnection: Symbol.for("ApiConnection"),

  // Repositories
  IProductoRepository: Symbol.for("IProductoRepository"),
  IProveedorRepository: Symbol.for("IProveedorRepository"),
  IPedidoRepository: Symbol.for("IPedidoRepository"),
  IUsuarioRepository: Symbol.for("IUsuarioRepository"),
  IDetallesPedidoRepository: Symbol.for("IDetallesPedidoRepository"),

  // UseCases
  IGetProductosUseCase: Symbol.for("IGetProductosUseCase"),
  IGetProveedoresUseCase: Symbol.for("IGetProveedoresUseCase"),

  IGetPedidosUseCase: Symbol.for("IGetPedidosUseCase"),
  ICreatePedidoUseCase: Symbol.for("ICreatePedidoUseCase"),
  IUpdatePedidoUseCase: Symbol.for("IUpdatePedidoUseCase"),
  ICambiarEstadoPedidoUseCase: Symbol.for("ICambiarEstadoPedidoUseCase"),
  IDeletePedidoUseCase: Symbol.for("IDeletePedidoUseCase"),

  IGetDetallesPedidoUseCase: Symbol.for("IGetDetallesPedidoUseCase"),
  ICreateDetallePedidoUseCase: Symbol.for("ICreateDetallePedidoUseCase"),
  IUpdateDetallePedidoUseCase: Symbol.for("IUpdateDetallePedidoUseCase"),
  IDeleteDetallePedidoUseCase: Symbol.for("IDeleteDetallePedidoUseCase"),

  // Viewmodels
  LoginViewModel: Symbol.for("LoginViewModel"),
  ListadoPedidosProveedoresViewModel: Symbol.for("ListadoPedidosProveedoresViewModel"),
  CreatePedidosProveedoresViewModel: Symbol.for("CreatePedidosProveedoresViewModel"),
  DetailsPedidosProveedoresViewModel: Symbol.for("DetailsPedidosProveedoresViewModel"),
  UpdatePedidosProveedoresViewModel: Symbol.for("UpdatePedidosProveedoresViewModel"),
  ArchivadosVM: Symbol.for("ArchivadosVM"),

};
