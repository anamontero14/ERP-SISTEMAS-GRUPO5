using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers.API
{
    /// <summary>
    /// Controlador API para gestionar detalles de pedidos.
    /// Permite operaciones de lectura (GET), creación (POST),
    /// actualización parcial (PATCH) y eliminación (DELETE).
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
            List<DetallePedido> detalles = _detallesPedidoUseCase.GetListaDetallesPorPedido(idPedido);
            return Ok(detalles);
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
            DetallePedido detalle = _detallesPedidoUseCase.GetDetallePedidoPorId(idPedido, idProducto);
            if (detalle == null) return NotFound();
            return Ok(detalle);
        }

        /// <summary>
        /// Crea un nuevo detalle de pedido.
        /// </summary>
        /// <param name="detallePedidoNuevo">Detalle de pedido a crear</param>
        /// <returns>201 si se creó correctamente</returns>
        // POST: api/DetallesPedido
        [HttpPost]
        public IActionResult CrearDetallePedido([FromBody] DetallePedido detallePedidoNuevo)
        {
            int resultado = _detallesPedidoUseCase.CrearDetallePedido(detallePedidoNuevo);
            if (resultado == 0) return BadRequest();
            return Created("", detallePedidoNuevo);
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
            int resultado = _detallesPedidoUseCase.ActualizarDetallePedido(idPedido, idProducto, detallePedido);
            if (resultado == 0) return NotFound();
            return Ok();
        }

        /// <summary>
        /// Elimina un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>200 si se eliminó, 404 si no se encontró</returns>
        // DELETE: api/DetallesPedido/5/3
        [HttpDelete("{idPedido}/{idProducto}")]
        public IActionResult EliminarDetallePedido(int idPedido, int idProducto)
        {
            int resultado = _detallesPedidoUseCase.EliminarDetallePedido(idPedido, idProducto);
            if (resultado == 0) return NotFound();
            return Ok();
        }
    }
}