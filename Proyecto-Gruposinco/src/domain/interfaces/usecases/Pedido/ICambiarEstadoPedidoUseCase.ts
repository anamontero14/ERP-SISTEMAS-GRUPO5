export interface ICambiarEstadoPedidoUseCase {
  cambiarEstadoPedido(idPedido: number, nuevoEstado: string): Promise<number>;
}
