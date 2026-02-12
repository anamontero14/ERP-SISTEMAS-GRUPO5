export class clsDetallePedido {
    private idPedido: number;
    private idProducto: number;
    private cantidad: number;
    private precioUnitario: number;

    constructor(idPedido: number, idProducto: number, cantidad: number, precioUnitario: number) {
        this.idPedido = idPedido;
        this.idProducto = idProducto;
        this.cantidad = cantidad;
        this.precioUnitario = precioUnitario;
    }

    get IdPedido() { return this.idPedido }

    get IdProducto() { return this.idProducto }
    set IdProducto(v: number) { this.idProducto = v }

    get Cantidad() { return this.cantidad }
    set Cantidad(v: number) { this.cantidad = v }

    get PrecioUnitario() { return this.precioUnitario }
    set PrecioUnitario(v: number) { this.precioUnitario = v }
}
