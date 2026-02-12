export class PedidoDTO {
  private _idPedido: number;
  private _idProveedor: number;
  private _idUsuario: number;
  private _fechaPedido: Date;
  private _estado: string;
  private _observaciones: string;

  constructor(idPedido: number, idProveedor: number, idUsuario: number, fechaPedido: Date, estado: string, observaciones: string) {
    this._idPedido = idPedido;
    this._idProveedor = idProveedor;
    this._idUsuario = idUsuario;
    this._fechaPedido = fechaPedido;
    this._estado = estado;
    this._observaciones = observaciones;
  }

}
