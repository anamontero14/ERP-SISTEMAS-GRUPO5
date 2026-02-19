using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers.API
{
    /// <summary>
    /// Controlador API para gestionar detalles de pedidos.
    /// Permite operaciones de lectura (GET), creación (POST)
    /// y actualización parcial (PATCH).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        // Caso de uso de detalles de pedido inyectado por dependencias
        private readonly IDetallesPedidoUseCase _detallesPedidoUseCase;

        /// <summary>
        /// Constructor del controlador de detalles de pedido.
        /// </summary>
        /// <param name="detallesPedidoUseCase">Caso de uso de detalles de pedido</param>
        public DetallesPedidoController(IDetallesPedidoUseCase detallesPedidoUseCase)
        {
            _detallesPedidoUseCase = detallesPedidoUseCase;
        }

        /// <summary>
        /// Obtiene la lista de detalles de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <returns>Lista de detalles del pedido</returns>
        // GET: api/DetallesPedido/pedido/5
        [HttpGet("pedido/{idPedido}")]
        public IActionResult GetListaDetallesPorPedido(int idPedido)
        {
            try
            {
                List<DetallePedido> detalles = _detallesPedidoUseCase.GetListaDetallesPorPedido(idPedido);
                return Ok(detalles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener los detalles del pedido: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Detalle encontrado o 404 si no existe</returns>
        // GET: api/DetallesPedido/5/3
        [HttpGet("{idPedido}/{idProducto}")]
        public IActionResult GetDetallePedidoPorId(int idPedido, int idProducto)
        {
            try
            {
                DetallePedido detalle = _detallesPedidoUseCase.GetDetallePedidoPorId(idPedido, idProducto);
                if (detalle == null) return NotFound();
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener el detalle del pedido: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>200 si se actualizó, 404 si no se encontró</returns>
        // PATCH: api/DetallesPedido/5/3
        [HttpPatch("{idPedido}/{idProducto}")]
        public IActionResult ActualizarDetallePedido(int idPedido, int idProducto, [FromBody] DetallePedido detallePedido)
        {
            try
            {
                int resultado = _detallesPedidoUseCase.ActualizarDetallePedido(idPedido, idProducto, detallePedido);
                if (resultado == 0) return NotFound();
                if (resultado == -1) return BadRequest("El pedido no se puede modificar porque ya fue enviado o entregado.");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al actualizar el detalle del pedido: {ex.Message}");
            }
        }
    }
}