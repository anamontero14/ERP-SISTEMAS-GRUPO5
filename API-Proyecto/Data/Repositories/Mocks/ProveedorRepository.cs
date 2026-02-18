/*using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio de Proveedor con datos mock en memoria.
    /// Implementa la interfaz IProveedorRepository.
    /// </summary>
    public class ProveedorRepository : IProveedorRepository
    {
        // Lista estática en memoria que simula la tabla PROVEEDOR
        private static List<Proveedor> listaProveedores = new List<Proveedor>
        {
            new Proveedor(1, "A12345678", "Suministros García", "954112233", "garcia@email.com", "Calle Sierpes 15, Sevilla"),
            new Proveedor(2, "B87654321", "Ferretería López", "955443322", "lopez@email.com", "Av. de la Constitución 8, Sevilla"),
            new Proveedor(3, "C11223344", "Distribuciones Martínez", "956778899", "martinez@email.com", "Calle Betis 22, Sevilla"),
            new Proveedor(4, "D55667788", "Materiales del Sur", "957665544", "sur@email.com", "Calle Feria 45, Sevilla"),
            new Proveedor(5, "E99887766", "Importaciones Ruiz", "958334455", "ruiz@email.com", "Av. Kansas City 10, Sevilla")
        };

        // Contador para generar IDs automáticamente
        private static int contadorId = 6;

        /// <summary>
        /// Obtiene la lista completa de proveedores.
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        public List<Proveedor> GetListaProveedores()
        {
            return listaProveedores;
        }

        /// <summary>
        /// Obtiene un proveedor por su identificador.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a buscar</param>
        /// <returns>Proveedor encontrado o null si no existe</returns>
        public Proveedor GetProveedorPorId(int idProveedor)
        {
            return listaProveedores.FirstOrDefault(p => p.getIdProveedor() == idProveedor);
        }

        /// <summary>
        /// Crea un nuevo proveedor.
        /// </summary>
        /// <param name="proveedorNuevo">Proveedor a crear</param>
        /// <returns>1 si se creó correctamente, 0 en caso contrario</returns>
        public int CrearProveedor(Proveedor proveedorNuevo)
        {
            Proveedor proveedor = new Proveedor(
                contadorId++,
                proveedorNuevo.getCifProveedor(),
                proveedorNuevo.getNombreProveedor(),
                proveedorNuevo.getTelefonoProveedor(),
                proveedorNuevo.getEmailProveedor(),
                proveedorNuevo.getDireccionProveedor()
            );
            listaProveedores.Add(proveedor);
            return 1;
        }

        /// <summary>
        /// Actualiza un proveedor existente.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a actualizar</param>
        /// <param name="proveedor">Datos actualizados del proveedor</param>
        /// <returns>1 si se actualizó correctamente, 0 si no se encontró</returns>
        public int ActualizarProveedor(int idProveedor, Proveedor proveedor)
        {
            Proveedor proveedorExistente = listaProveedores.FirstOrDefault(p => p.getIdProveedor() == idProveedor);
            if (proveedorExistente == null) return 0;

            proveedorExistente.setCifProveedor(proveedor.getCifProveedor());
            proveedorExistente.setNombreProveedor(proveedor.getNombreProveedor());
            proveedorExistente.setTelefonoProveedor(proveedor.getTelefonoProveedor());
            proveedorExistente.setEmailProveedor(proveedor.getEmailProveedor());
            proveedorExistente.setDireccionProveedor(proveedor.getDireccionProveedor());
            return 1;
        }

        /// <summary>
        /// Elimina un proveedor por su identificador.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a eliminar</param>
        /// <returns>1 si se eliminó correctamente, 0 si no se encontró</returns>
        public int EliminarProveedor(int idProveedor)
        {
            Proveedor proveedor = listaProveedores.FirstOrDefault(p => p.getIdProveedor() == idProveedor);
            if (proveedor == null) return 0;

            listaProveedores.Remove(proveedor);
            return 1;
        }
    }
}
*/