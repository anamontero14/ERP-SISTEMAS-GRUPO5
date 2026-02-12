import { clsProducto } from '../../domain/entities/clsProducto';
import { IProductoRepository } from '../../domain/interfaces/repositories/IProductoRepository';

export class ProductoRepository implements IProductoRepository {

    // Mock Productos
    private readonly productosMock: clsProducto[] = [
        new clsProducto(1, 'Laptop Pro 14', 'Portátil de alto rendimiento con 16GB RAM', 1200, 15, 'Importado'),
        new clsProducto(2, 'Monitor 4K', 'Monitor ultra HD de 27 pulgadas', 350, 10, 'Nacional'),
        new clsProducto(3, 'Teclado Mecánico', 'Teclado RGB con switches blue', 85, 50, 'Importado'),
        new clsProducto(4, 'Mouse Ergonómico', 'Mouse inalámbrico con sensor óptico', 45, 100, 'Nacional'),
        new clsProducto(5, 'Silla de Oficina', 'Silla ergonómica con soporte lumbar', 210, 8, 'Nacional'),
        new clsProducto(6, 'Disco Duro SSD 1TB', 'Unidad de estado sólido alta velocidad', 110, 25, 'Importado'),
        new clsProducto(7, 'Impresora Láser', 'Impresora blanco y negro multifunción', 180, 5, 'Importado'),
        new clsProducto(8, 'Escritorio Elevable', 'Mesa con motor eléctrico para trabajar de pie', 450, 3, 'Nacional'),
        new clsProducto(9, 'Auriculares Noise Cancelling', 'Auriculares con cancelación de ruido activa', 190, 12, 'Importado'),
        new clsProducto(10, 'Webcam 1080p', 'Cámara para streaming con micrófono dual', 65, 30, 'Nacional')
    ];

    // GetListado Productos
    async getListaProductos(): Promise<clsProducto[]> {
        return new Promise((resolve) => {
            setTimeout(() => {
                resolve(this.productosMock);
            }, 100);
        });
    }

    // GetPorId Productos
    async getProductoPorId(idProducto: number): Promise<clsProducto> {
        const producto = this.productosMock.find(p => p.IdProducto === idProducto);
        if (!producto) {
            throw new Error(`Producto con id ${idProducto} no encontrado`);
        }
        return Promise.resolve(producto);
    }
}