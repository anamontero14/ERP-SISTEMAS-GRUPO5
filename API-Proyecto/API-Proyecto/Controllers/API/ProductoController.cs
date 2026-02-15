using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers.API
{
    /// <summary>
    /// Controlador API para gestionar productos.
    /// Solo permite operaciones de lectura (GET).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // Caso de uso de producto inyectado por dependencias
        private readonly IProductoUseCase _productoUseCase;

        /// <summary>
        /// Constructor del controlador de productos.
        /// </summary>
        /// <param name="productoUseCase">Caso de uso de producto</param>
        public ProductoController(IProductoUseCase productoUseCase)
        {
            _productoUseCase = productoUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de productos.
        /// </summary>
        /// <returns>Lista de productos</returns>
        // GET: api/Producto
        [HttpGet]
        public IActionResult GetListaProductos()
        {
            List<Producto> productos = _productoUseCase.GetListaProductos();
            return Ok(productos);
        }

        /// <summary>
        /// Obtiene un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a buscar</param>
        /// <returns>Producto encontrado o 404 si no existe</returns>
        // GET: api/Producto/5
        [HttpGet("{idProducto}")]
        public IActionResult GetProductoPorId(int idProducto)
        {
            Producto producto = _productoUseCase.GetProductoPorId(idProducto);
            if (producto == null) return NotFound();
            return Ok(producto);
        }
    }
}