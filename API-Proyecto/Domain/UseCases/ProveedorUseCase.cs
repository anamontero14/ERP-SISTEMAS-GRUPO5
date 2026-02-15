using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;

namespace UseCases
{
    public class ProveedorUseCase : IProveedorUseCase
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorUseCase(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public List<Proveedor> GetListaProveedores()
        {
            return _proveedorRepository.GetListaProveedores();
        }

        public Proveedor GetProveedorPorId(int idProveedor)
        {
            return _proveedorRepository.GetProveedorPorId(idProveedor);
        }
    }
}