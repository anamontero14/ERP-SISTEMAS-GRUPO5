using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    /// <summary>
    /// Interfaz que define las operaciones del caso de uso de Proveedor.
    /// </summary>
    public interface IProveedorUseCase
    {
        /// <summary>
        /// Obtiene la lista completa de proveedores.
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        List<Proveedor> GetListaProveedores();

        /// <summary>
        /// Obtiene un proveedor por su identificador.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a buscar</param>
        /// <returns>Proveedor encontrado</returns>
        Proveedor GetProveedorPorId(int idProveedor);
    }
}