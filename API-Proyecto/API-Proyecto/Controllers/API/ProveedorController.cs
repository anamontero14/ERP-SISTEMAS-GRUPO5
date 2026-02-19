using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers.API
{
    /// <summary>
    /// Controlador API para gestionar proveedores.
    /// Solo permite operaciones de lectura (GET).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        /// <summary>
        /// Atributo que almacena el caso de uso para poder usar sus métodos
        /// </summary>
        private readonly IProveedorUseCase _proveedorUseCase;

        /// <summary>
        /// Inyección del caso de uso de proveedores
        /// </summary>
        /// <param name="proveedorUseCase">Caso de uso de proveedor</param>
        public ProveedorController(IProveedorUseCase proveedorUseCase)
        {
            _proveedorUseCase = proveedorUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de proveedores llamando al caso de uso.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        // GET: api/Proveedor
        [HttpGet]
        public IActionResult GetListaProveedores()
        {
            IActionResult resultado;
            try
            {
                List<Proveedor> proveedores = _proveedorUseCase.GetListaProveedores();
                resultado = Ok(proveedores);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener la lista de proveedores: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene un proveedor por su identificador llamando al caso de uso.
        /// Si no se encuentra el proveedor, devuelve 404.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a buscar</param>
        /// <returns>Proveedor encontrado o 404 si no existe</returns>
        // GET: api/Proveedor/5
        [HttpGet("{idProveedor}")]
        public IActionResult GetProveedorPorId(int idProveedor)
        {
            IActionResult resultado;
            try
            {
                Proveedor proveedor = _proveedorUseCase.GetProveedorPorId(idProveedor);
                resultado = proveedor == null ? NotFound() : Ok(proveedor);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener el proveedor: {ex.Message}");
            }
            return resultado;
        }
    }
}