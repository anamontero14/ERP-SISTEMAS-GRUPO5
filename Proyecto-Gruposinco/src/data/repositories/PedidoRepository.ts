import { clsPedido } from '../../domain/entities/clsPedido';
import { IPedidoRepository } from '../../domain/interfaces/repositories/IPedidoRepository';

export class PedidoRepository implements IPedidoRepository {

    // Mock Pedidos
    private pedidosMock: clsPedido[] = [
        new clsPedido(1, 1, 3, new Date('2024-01-10'), 'entregado', 'Urgente', false),
        new clsPedido(2, 2, 1, new Date('2024-01-15'), 'en preparación', 'Fragil', false),
        new clsPedido(3, 1, 5, new Date('2024-02-01'), 'pedido', '', false),
        new clsPedido(4, 2, 2, new Date('2024-02-05'), 'entregado', 'Entregar tarde', false),
        new clsPedido(5, 1, 8, new Date('2024-02-10'), 'en preparación', '', false),
        new clsPedido(6, 2, 10, new Date('2024-02-12'), 'pedido', 'Revisar embalaje', false),
        new clsPedido(7, 1, 4, new Date('2024-02-14'), 'pedido', '', false),
        new clsPedido(8, 2, 6, new Date('2024-02-15'), 'entregado', 'Todo correcto', true),
        new clsPedido(9, 1, 7, new Date('2024-02-16'), 'en preparación', '', false),
        new clsPedido(10, 2, 9, new Date('2024-02-17'), 'pedido', 'Llamar antes', false)
    ];

    // GetListado Pedidos
    async getListaPedidos(): Promise<clsPedido[]> {
        return Promise.resolve([...this.pedidosMock]);
    }

    // GetPorUsuario Pedidos
    async getListaPedidosPorUsuario(idUsuario: number): Promise<clsPedido[]> {
        const filtrados = this.pedidosMock.filter(p => p.IdUsuario === idUsuario);
        return Promise.resolve(filtrados);
    }

    // GetPorProveedor Pedidos
    async getListaPedidosPorProveedor(idProveedor: number): Promise<clsPedido[]> {
        const filtrados = this.pedidosMock.filter(p => p.IdProveedor === idProveedor);
        return Promise.resolve(filtrados);
    }

    // GetPorId Pedidos
    async getPedidoPorId(idPedido: number): Promise<clsPedido> {
        const pedido = this.pedidosMock.find(p => p.IdPedido === idPedido);
        if (!pedido) throw new Error(`Pedido ${idPedido} no encontrado`);
        return Promise.resolve(pedido);
    }

    // Create Pedido
    // return 1 = OK
    async crearPedido(pedidoNuevo: clsPedido): Promise<number> {
        this.pedidosMock.push(pedidoNuevo);
        return Promise.resolve(1); // 1 = OK
    }

    // Update Pedido
    // return 1 = OK
    async actualizarPedido(idPedido: number, pedido: clsPedido): Promise<number> {
        const index = this.pedidosMock.findIndex(p => p.IdPedido === idPedido);
        if (index !== -1) {
            this.pedidosMock[index] = pedido;
            return Promise.resolve(1); // 1 = OK
        }
        return Promise.resolve(0);
    }

    // UpdateEstado Pedido
    // return 1 = OK
    async cambiarEstadoPedido(idPedido: number, nuevoEstado: "pedido" | "en preparación" | "entregado"): Promise<number> {
        const pedido = this.pedidosMock.find(p => p.IdPedido === idPedido);
        if (pedido) {
            pedido.Estado = nuevoEstado;
            return Promise.resolve(1); // 1 = OK
        }
        return Promise.resolve(0);
    }

    // Delete Pedido
    // return 1 = OK
    async eliminarPedido(idPedido: number): Promise<number> {
        const inicial = this.pedidosMock.length;
        this.pedidosMock = this.pedidosMock.filter(p => p.IdPedido !== idPedido);
        return Promise.resolve(this.pedidosMock.length < inicial ? 1 : 0); // 1 = OK
    }
}