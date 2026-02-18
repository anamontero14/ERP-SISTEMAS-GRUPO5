using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    /// <summary>
    /// Interfaz que define las operaciones del caso de uso de Producto.
    /// </summary>
    public interface IProductoUseCase
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
    }
}