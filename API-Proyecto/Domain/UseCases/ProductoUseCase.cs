using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Interfaces.Repositories;
using System.Collections.Generic;

namespace UseCases
{
    public class ProductoUseCase : IProductoUseCase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<Producto> GetListaProductos()
        {
            return _productoRepository.GetListaProductos();
        }

        public Producto GetProductoPorId(int idProducto)
        {
            return _productoRepository.GetProductoPorId(idProducto);
        }
    }
}
