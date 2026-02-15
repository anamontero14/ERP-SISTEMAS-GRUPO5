using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define las operaciones del repositorio de Proveedor.
    /// </summary>
    public interface IProveedorRepository
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
        /// <returns>Proveedor encontrado o null si no existe</returns>
        Proveedor? GetProveedorPorId(int idProveedor);
    }
}