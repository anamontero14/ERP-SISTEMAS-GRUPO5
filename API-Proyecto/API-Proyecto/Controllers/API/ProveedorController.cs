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
        // Caso de uso de proveedor inyectado por dependencias
        private readonly IProveedorUseCase _proveedorUseCase;

        /// <summary>
        /// Constructor del controlador de proveedores.
        /// </summary>
        /// <param name="proveedorUseCase">Caso de uso de proveedor</param>
        public ProveedorController(IProveedorUseCase proveedorUseCase)
        {
            _proveedorUseCase = proveedorUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de proveedores.
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        // GET: api/Proveedor
        [HttpGet]
        public IActionResult GetListaProveedores()
        {
            try
            {
                List<Proveedor> proveedores = _proveedorUseCase.GetListaProveedores();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener la lista de proveedores: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene un proveedor por su identificador.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a buscar</param>
        /// <returns>Proveedor encontrado o 404 si no existe</returns>
        // GET: api/Proveedor/5
        [HttpGet("{idProveedor}")]
        public IActionResult GetProveedorPorId(int idProveedor)
        {
            try
            {
                Proveedor proveedor = _proveedorUseCase.GetProveedorPorId(idProveedor);
                if (proveedor == null) return NotFound();
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener el proveedor: {ex.Message}");
            }
        }
    }
}