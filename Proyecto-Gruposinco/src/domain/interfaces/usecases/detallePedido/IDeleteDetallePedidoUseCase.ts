export interface IDeleteDetallePedidoUseCase {
  eliminarDetallePedido(idPedido: number, idProducto: number): Promise<number>;
}
