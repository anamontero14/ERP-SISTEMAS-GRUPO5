using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio de Producto con datos mock en memoria.
    /// Implementa la interfaz IProductoRepository.
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        // Lista estática en memoria que simula la tabla PRODUCTO
        private static List<Producto> listaProductos = new List<Producto>
        {
            new Producto(1, "Tornillos 5mm", "Tornillos de acero inoxidable 5mm", 2.50m, 500, "España"),
            new Producto(2, "Martillo", "Martillo de carpintero 300g", 12.99m, 150, "Alemania"),
            new Producto(3, "Sierra circular", "Sierra circular 1200W", 89.95m, 30, "Japón"),
            new Producto(4, "Cinta métrica", "Cinta métrica 5 metros", 5.75m, 200, "China"),
            new Producto(5, "Taladro", "Taladro percutor 750W", 65.00m, 45, "España")
        };

        // Contador para generar IDs automáticamente
        private static int contadorId = 6;

        /// <summary>
        /// Obtiene la lista completa de productos.
        /// </summary>
        /// <returns>Lista de productos</returns>
        public List<Producto> GetListaProductos()
        {
            return listaProductos;
        }

        /// <summary>
        /// Obtiene un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a buscar</param>
        /// <returns>Producto encontrado o null si no existe</returns>
        public Producto GetProductoPorId(int idProducto)
        {
            return listaProductos.FirstOrDefault(p => p.getIdProducto() == idProducto);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productoNuevo">Producto a crear</param>
        /// <returns>1 si se creó correctamente, 0 en caso contrario</returns>
        public int CrearProducto(Producto productoNuevo)
        {
            Producto producto = new Producto(
                contadorId++,
                productoNuevo.getNombreProducto(),
                productoNuevo.getDescripcionProducto(),
                productoNuevo.getPrecioProducto(),
                productoNuevo.getStockProducto(),
                productoNuevo.getProcedenciaProducto()
            );
            listaProductos.Add(producto);
            return 1;
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="idProducto">ID del producto a actualizar</param>
        /// <param name="producto">Datos actualizados del producto</param>
        /// <returns>1 si se actualizó correctamente, 0 si no se encontró</returns>
        public int ActualizarProducto(int idProducto, Producto producto)
        {
            Producto productoExistente = listaProductos.FirstOrDefault(p => p.getIdProducto() == idProducto);
            if (productoExistente == null) return 0;

            productoExistente.setNombreProducto(producto.getNombreProducto());
            productoExistente.setDescripcionProducto(producto.getDescripcionProducto());
            productoExistente.setPrecioProducto(producto.getPrecioProducto());
            productoExistente.setStockProducto(producto.getStockProducto());
            productoExistente.setProcedenciaProducto(producto.getProcedenciaProducto());
            return 1;
        }

        /// <summary>
        /// Elimina un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a eliminar</param>
        /// <returns>1 si se eliminó correctamente, 0 si no se encontró</returns>
        public int EliminarProducto(int idProducto)
        {
            Producto producto = listaProductos.FirstOrDefault(p => p.getIdProducto() == idProducto);
            if (producto == null) return 0;

            listaProductos.Remove(producto);
            return 1;
        }
    }
}