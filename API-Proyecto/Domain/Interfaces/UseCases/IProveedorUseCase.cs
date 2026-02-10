using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    public interface IProveedorUseCase
    {
        List<Proveedor> GetListaProveedores();
        Proveedor GetProveedorPorId(int idProveedor);
    }
}
