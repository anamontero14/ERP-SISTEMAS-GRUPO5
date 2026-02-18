export class clsPedido {
  private idPedido: number;
  private idUsuario: number;
  private idProveedor: number;
  private fechaPedido: Date;
  private estado: "pedido" | "enviado" | "entregado";
  private observaciones: string;
  private archivado: boolean;

  constructor(
    idPedido: number,
    idUsuario: number,
    idProveedor: number,
    fechaPedido: Date,
    estado: "pedido" | "enviado" | "entregado",
    observaciones: string,
    archivado: boolean,
  ) {
    this.idPedido = idPedido;
    this.idUsuario = idUsuario;
    this.idProveedor = idProveedor;
    this.fechaPedido = fechaPedido;
    this.estado = estado;
    this.observaciones = observaciones;
    this.archivado = archivado;
  }

  get IdPedido() {
    return this.idPedido;
  }

  get IdUsuario() {
    return this.idUsuario;
  }
  set IdUsuario(v: number) {
    this.idUsuario = v;
  }

  get IdProveedor() {
    return this.idProveedor;
  }
  set IdProveedor(v: number) {
    this.idProveedor = v;
  }

  get FechaPedido() {
    return this.fechaPedido;
  }
  set FechaPedido(v: Date) {
    this.fechaPedido = v;
  }

  get Estado() {
    return this.estado;
  }
  set Estado(v: "pedido" | "enviado" | "entregado") {
    this.estado = v;
  }

  get Observaciones() {
    return this.observaciones;
  }
  set Observaciones(v: string) {
    this.observaciones = v;
  }

  get Archivado() {
    return this.archivado;
  }
  set Archivado(v: boolean) {
    this.archivado = v;
  }
}
