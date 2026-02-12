export class clsProducto {
    private idProducto: number;
    private nombreProducto: string;
    private descripcionProducto: string;
    private precioProducto: number;
    private stockProducto: number;
    private procedenciaProducto: string;

    constructor(idProducto: number, nombreProducto: string, descripcionProducto: string, precioProducto: number, stockProducto: number, procedenciaProducto: string) {
        this.idProducto = idProducto;
        this.nombreProducto = nombreProducto;
        this.descripcionProducto = descripcionProducto;
        this.precioProducto = precioProducto;
        this.stockProducto = stockProducto;
        this.procedenciaProducto = procedenciaProducto;
    }

    get IdProducto() { return this.idProducto }

    get NombreProducto() { return this.nombreProducto }
    set NombreProducto(v: string) { this.nombreProducto = v }

    get DescripcionProducto() { return this.descripcionProducto }
    set DescripcionProducto(v: string) { this.descripcionProducto = v }

    get PrecioProducto() { return this.precioProducto }
    set PrecioProducto(v: number) { this.precioProducto = v }

    get StockProducto() { return this.stockProducto }
    set StockProducto(v: number) { this.stockProducto = v }

    get ProcedenciaProducto() { return this.procedenciaProducto }
    set ProcedenciaProducto(v: string) { this.procedenciaProducto = v }
}
