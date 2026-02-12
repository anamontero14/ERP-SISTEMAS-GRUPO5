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
        /// <returns>Producto encontrado o null si no existe</returns>
        Producto? GetProductoPorId(int idProducto);
    }
}