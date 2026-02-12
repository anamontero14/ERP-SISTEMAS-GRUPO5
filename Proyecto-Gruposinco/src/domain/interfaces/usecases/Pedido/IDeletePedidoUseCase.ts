export interface IDeletePedidoUseCase {
  eliminarPedido(idPedido: number): Promise<number>;
}
