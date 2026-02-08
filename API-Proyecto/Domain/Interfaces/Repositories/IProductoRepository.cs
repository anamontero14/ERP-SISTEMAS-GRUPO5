using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define las operaciones del repositorio de Producto.
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Obtiene la lista completa de productos.
        /// </summary>
        /// <returns>Lista de productos</returns>
        List<Producto> GetListaProductos();

        /// <summary>
        /// Obtiene un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a buscar</param>
        /// <returns>Producto encontrado</returns>
        Producto GetProductoPorId(int idProducto);

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productoNuevo">Producto a crear</param>
        /// <returns>Número de filas afectadas</returns>
        int CrearProducto(Producto productoNuevo);

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="idProducto">ID del producto a actualizar</param>
        /// <param name="producto">Datos actualizados del producto</param>
        /// <returns>Número de filas afectadas</returns>
        int ActualizarProducto(int idProducto, Producto producto);

        /// <summary>
        /// Elimina un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        int EliminarProducto(int idProducto);
    }
}
