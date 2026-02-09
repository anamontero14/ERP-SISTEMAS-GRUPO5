export class clsUsuario {
    private idUsuario: number;
    private nombre: string;
    private email: string;

    constructor(idUsuario: number, nombre: string, email: string) {
        this.idUsuario = idUsuario;
        this.nombre = nombre;
        this.email = email;
    }

    get IdUsuario() { return this.idUsuario }

    get Nombre() { return this.nombre }
    set Nombre(v: string) { this.nombre = v }

    get Email() { return this.email }
    set Email(v: string) { this.email = v }
}
