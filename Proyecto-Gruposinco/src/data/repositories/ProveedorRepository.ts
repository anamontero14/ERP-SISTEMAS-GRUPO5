import { clsProveedor } from '../../domain/entities/clsProveedor';
import { IProveedorRepository } from '../../domain/interfaces/repositories/IProveedorRepository';

export class ProveedorRepository implements IProveedorRepository {

    // Mock de Proveedores
    private readonly proveedoresMock: clsProveedor[] = [
        new clsProveedor(1, 'A12345678', 'Suministros Industriales S.L.', '912345678', 'contacto@suministros.com', 'Calle Principal 123, Madrid'),
        new clsProveedor(2, 'B87654321', 'Tecnología Global S.A.', '934567890', 'ventas@tecnoglobal.es', 'Avenida Libertad 45, Barcelona'),
        new clsProveedor(3, 'C45678912', 'Logística Express', '954123456', 'info@logex.com', 'Polígono Industrial Norte, Sevilla'),
        new clsProveedor(4, 'D98765432', 'Papelería Central', '963852741', 'pedidos@papelcentral.com', 'Calle Mayor 12, Valencia'),
        new clsProveedor(5, 'E15926348', 'Energías Renovables S.A.', '981726354', 'bio@energia.es', 'Camino del Sol s/n, Bilbao'),
        new clsProveedor(6, 'F35715924', 'Mantenimiento Integral', '922334455', 'soporte@manteni.com', 'Calle de la Paz 8, Málaga'),
        new clsProveedor(7, 'G24681357', 'Catering Eventos', '941258963', 'eventos@catering.com', 'Avenida de la Constitución 101, Zaragoza'),
        new clsProveedor(8, 'H13579246', 'Limpiezas Brillante', '958741236', 'limpieza@brillante.com', 'Callejón del Gato 4, Granada'),
        new clsProveedor(9, 'I86420975', 'Seguridad Pro', '910001122', 'seguridad@pro.es', 'Paseo de la Castellana 200, Madrid'),
        new clsProveedor(10, 'J75315984', 'Construcciones Rápidas', '933445566', 'obras@corapid.com', 'Ronda de San Pedro 15, Barcelona')
    ];

    // GetListado Proveedores
    async getListaProveedores(): Promise<clsProveedor[]> {
        return new Promise((resolve) => {
            setTimeout(() => {
                resolve(this.proveedoresMock);
            }, 100); 
        });
    }

    // GetPorId Proveedores
    async getProveedorPorId(idProveedor: number): Promise<clsProveedor> {
        const proveedor = this.proveedoresMock.find(p => p.IdProveedor === idProveedor);
        if (!proveedor) {
            throw new Error(`Proveedor con id ${idProveedor} no encontrado`);
        }
        return Promise.resolve(proveedor);
    }
}