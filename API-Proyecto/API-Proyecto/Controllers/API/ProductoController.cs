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
        /// <summary>
        /// Atributo que almacena el caso de uso para poder usar sus métodos
        /// </summary>
        private readonly IProductoUseCase _productoUseCase;

        /// <summary>
        /// Inyección del caso de uso de productos
        /// </summary>
        /// <param name="productoUseCase">Caso de uso de producto</param>
        public ProductoController(IProductoUseCase productoUseCase)
        {
            _productoUseCase = productoUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de productos llamando al caso de uso.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <returns>Lista de productos</returns>
        // GET: api/Producto
        [HttpGet]
        public IActionResult GetListaProductos()
        {
            IActionResult resultado;
            try
            {
                List<Producto> productos = _productoUseCase.GetListaProductos();
                resultado = Ok(productos);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener la lista de productos: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene un producto por su identificador llamando al caso de uso.
        /// Si no se encuentra el producto, devuelve 404.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idProducto">ID del producto a buscar</param>
        /// <returns>Producto encontrado o 404 si no existe</returns>
        // GET: api/Producto/5
        [HttpGet("{idProducto}")]
        public IActionResult GetProductoPorId(int idProducto)
        {
            IActionResult resultado;
            try
            {
                Producto producto = _productoUseCase.GetProductoPorId(idProducto);
                resultado = producto == null ? NotFound() : Ok(producto);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener el producto: {ex.Message}");
            }
            return resultado;
        }
    }
}