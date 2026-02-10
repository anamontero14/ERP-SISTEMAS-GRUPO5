using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    public interface IProductoUseCase
    {
        List<Producto> GetListaProductos();
        Producto GetProductoPorId(int idProducto);
    }
}
