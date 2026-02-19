using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers.API
{
    /// <summary>
    /// Controlador API para gestionar detalles de pedidos.
    /// Permite operaciones de lectura (GET) y actualización parcial (PATCH).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        /// <summary>
        /// Atributo que almacena el caso de uso para poder usar sus métodos
        /// </summary>
        private readonly IDetallesPedidoUseCase _detallesPedidoUseCase;

        /// <summary>
        /// Inyección del caso de uso de detalles de pedido
        /// </summary>
        /// <param name="detallesPedidoUseCase">Caso de uso de detalles de pedido</param>
        public DetallesPedidoController(IDetallesPedidoUseCase detallesPedidoUseCase)
        {
            _detallesPedidoUseCase = detallesPedidoUseCase;
        }

        /// <summary>
        /// Obtiene la lista de detalles de un pedido dado su identificador.
        /// Llama al caso de uso y devuelve la lista en caso de éxito,
        /// o un error 500 si ocurre una excepción.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <returns>Lista de detalles del pedido</returns>
        // GET: api/DetallesPedido/pedido/5
        [HttpGet("pedido/{idPedido}")]
        public IActionResult GetListaDetallesPorPedido(int idPedido)
        {
            IActionResult resultado;
            try
            {
                List<DetallePedido> detalles = _detallesPedidoUseCase.GetListaDetallesPorPedido(idPedido);
                resultado = Ok(detalles);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener los detalles del pedido: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene un detalle de pedido por su clave compuesta (idPedido + idProducto).
        /// Si no se encuentra el detalle, devuelve 404.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Detalle encontrado o 404 si no existe</returns>
        // GET: api/DetallesPedido/5/3
        [HttpGet("{idPedido}/{idProducto}")]
        public IActionResult GetDetallePedidoPorId(int idPedido, int idProducto)
        {
            IActionResult resultado;
            try
            {
                DetallePedido detalle = _detallesPedidoUseCase.GetDetallePedidoPorId(idPedido, idProducto);
                resultado = detalle == null ? NotFound() : Ok(detalle);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener el detalle del pedido: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Actualiza un detalle de pedido existente identificado por su clave compuesta.
        /// Si el caso de uso devuelve 0, significa que no se encontró el detalle (404).
        /// Si devuelve -1, el pedido ya fue enviado o entregado y no puede modificarse (400).
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>200 si se actualizó, 404 si no se encontró, 400 si el estado no lo permite</returns>
        // PATCH: api/DetallesPedido/5/3
        [HttpPatch("{idPedido}/{idProducto}")]
        public IActionResult ActualizarDetallePedido(int idPedido, int idProducto, [FromBody] DetallePedido detallePedido)
        {
            IActionResult resultado;
            try
            {
                int codigoResultado = _detallesPedidoUseCase.ActualizarDetallePedido(idPedido, idProducto, detallePedido);
                if (codigoResultado == 0)
                    resultado = NotFound();
                else if (codigoResultado == -1)
                    resultado = BadRequest("El pedido no se puede modificar porque ya fue enviado o entregado.");
                else
                    resultado = Ok();
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al actualizar el detalle del pedido: {ex.Message}");
            }
            return resultado;
        }
    }
}