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
        /// <returns>Proveedor encontrado</returns>
        Proveedor GetProveedorPorId(int idProveedor);

        /// <summary>
        /// Crea un nuevo proveedor.
        /// </summary>
        /// <param name="proveedorNuevo">Proveedor a crear</param>
        /// <returns>Número de filas afectadas</returns>
        int CrearProveedor(Proveedor proveedorNuevo);

        /// <summary>
        /// Actualiza un proveedor existente.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a actualizar</param>
        /// <param name="proveedor">Datos actualizados del proveedor</param>
        /// <returns>Número de filas afectadas</returns>
        int ActualizarProveedor(int idProveedor, Proveedor proveedor);

        /// <summary>
        /// Elimina un proveedor por su identificador.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        int EliminarProveedor(int idProveedor);
    }
}
