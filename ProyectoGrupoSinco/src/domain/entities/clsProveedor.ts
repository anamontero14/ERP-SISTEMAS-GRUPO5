export class clsProveedor {
    private idProveedor: number;
    private cifProveedor: string;
    private nombreProveedor: string;
    private telefonoProveedor: string;
    private emailProveedor: string;
    private direccionProveedor: string;

    constructor(idProveedor: number, cifProveedor: string, nombreProveedor: string, telefonoProveedor: string, emailProveedor: string, direccionProveedor: string) {
        this.idProveedor = idProveedor;
        this.cifProveedor = cifProveedor;
        this.nombreProveedor = nombreProveedor;
        this.telefonoProveedor = telefonoProveedor;
        this.emailProveedor = emailProveedor;
        this.direccionProveedor = direccionProveedor;
    }

    get IdProveedor() { return this.idProveedor }

    get CifProveedor() { return this.cifProveedor }
    set CifProveedor(v: string) { this.cifProveedor = v }

    get NombreProveedor() { return this.nombreProveedor }
    set NombreProveedor(v: string) { this.nombreProveedor = v }

    get TelefonoProveedor() { return this.telefonoProveedor }
    set TelefonoProveedor(v: string) { this.telefonoProveedor = v }

    get EmailProveedor() { return this.emailProveedor }
    set EmailProveedor(v: string) { this.emailProveedor = v }

    get DireccionProveedor() { return this.direccionProveedor }
    set DireccionProveedor(v: string) { this.direccionProveedor = v }
}
