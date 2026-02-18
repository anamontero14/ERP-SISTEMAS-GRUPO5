using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;

namespace UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para la gestión de proveedores.
    /// Actúa como intermediario entre la capa de presentación y el repositorio.
    /// </summary>
    public class ProveedorUseCase : IProveedorUseCase
    {
        private readonly IProveedorRepository _proveedorRepository;

        /// <summary>
        /// Constructor del caso de uso Proveedor.
        /// </summary>
        /// <param name="proveedorRepository">Repositorio de proveedores</param>
        public ProveedorUseCase(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de proveedores registrados en el sistema.
        /// </summary>
        /// <returns>Lista de todos los proveedores</returns>
        public List<Proveedor> GetListaProveedores()
        {
            return _proveedorRepository.GetListaProveedores();
        }

        /// <summary>
        /// Obtiene un proveedor específico por su identificador.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a buscar</param>
        /// <returns>Proveedor encontrado</returns>
        public Proveedor GetProveedorPorId(int idProveedor)
        {
            return _proveedorRepository.GetProveedorPorId(idProveedor);
        }
    }
}