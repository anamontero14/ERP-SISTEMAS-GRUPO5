using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;

namespace UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para la gestión de productos.
    /// Actúa como intermediario entre la capa de presentación y el repositorio.
    /// </summary>
    public class ProductoUseCase : IProductoUseCase
    {
        private readonly IProductoRepository _productoRepository;

        /// <summary>
        /// Constructor del caso de uso Producto.
        /// </summary>
        /// <param name="productoRepository">Repositorio de productos</param>
        public ProductoUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de productos disponibles en el sistema.
        /// </summary>
        /// <returns>Lista de todos los productos</returns>
        public List<Producto> GetListaProductos()
        {
            return _productoRepository.GetListaProductos();
        }

        /// <summary>
        /// Obtiene un producto específico por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a buscar</param>
        /// <returns>Producto encontrado</returns>
        public Producto GetProductoPorId(int idProducto)
        {
            return _productoRepository.GetProductoPorId(idProducto);
        }
    }
}