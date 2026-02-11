import { clsDetallePedido } from '../../domain/entities/clsDetallePedido';
import { IDetallesPedidoRepository } from '../../domain/interfaces/repositories/IDetallesPedidoRepository';

export class DetallesPedidoRepository implements IDetallesPedidoRepository {

    // Mock Detalles pedidos
    private detallesMock: clsDetallePedido[] = [
        new clsDetallePedido(1, 1, 1, 1200), // Pedido 1: Laptop
        new clsDetallePedido(1, 4, 2, 45),   // Pedido 1: Mouse
        new clsDetallePedido(2, 2, 1, 350),  // Pedido 2: Monitor
        new clsDetallePedido(3, 3, 5, 85),   // Pedido 3: Teclado
        new clsDetallePedido(4, 5, 1, 210),  // Pedido 4: Silla
        new clsDetallePedido(5, 6, 3, 110),  // Pedido 5: SSD
        new clsDetallePedido(6, 10, 2, 65),  // Pedido 6: Webcam
        new clsDetallePedido(7, 7, 1, 180),  // Pedido 7: Impresora
        new clsDetallePedido(8, 8, 1, 450),  // Pedido 8: Escritorio
        new clsDetallePedido(9, 9, 2, 190)   // Pedido 9: Auriculares
    ];

    // GetPorPedido Detalles pedidos
    async getListaDetallesPorPedido(idPedido: number): Promise<clsDetallePedido[]> {
        const detalles = this.detallesMock.filter(d => d.IdPedido === idPedido);
        return Promise.resolve(detalles);
    }

    // GetPorId Detalles pedidos
    async getDetallePedidoPorId(idPedido: number, idProducto: number): Promise<clsDetallePedido> {
        const detalle = this.detallesMock.find(d => d.IdPedido === idPedido && d.IdProducto === idProducto);
        if (!detalle) throw new Error(`Detalle no encontrado para Pedido ${idPedido} y Producto ${idProducto}`);
        return Promise.resolve(detalle);
    }

    // Create Detalles pedidos
    // return 1 = OK
    async crearDetallePedido(detallePedidoNuevo: clsDetallePedido): Promise<number> {
        this.detallesMock.push(detallePedidoNuevo);
        return Promise.resolve(1);
    }

    // Update Detalles pedidos 
    // return 1 = OK
    async actualizarDetallePedido(idPedido: number, idProducto: number, detallePedido: clsDetallePedido): Promise<number> {
        const index = this.detallesMock.findIndex(d => d.IdPedido === idPedido && d.IdProducto === idProducto);
        if (index !== -1) {
            this.detallesMock[index] = detallePedido;
            return Promise.resolve(1);
        }
        return Promise.resolve(0);
    }

    // Delete Detalles pedidos
    // return 1 = OK
    async eliminarDetallePedido(idPedido: number, idProducto: number): Promise<number> {
        const longitudInicial = this.detallesMock.length;
        this.detallesMock = this.detallesMock.filter(d => !(d.IdPedido === idPedido && d.IdProducto === idProducto));
        return Promise.resolve(this.detallesMock.length < longitudInicial ? 1 : 0);
    }
}