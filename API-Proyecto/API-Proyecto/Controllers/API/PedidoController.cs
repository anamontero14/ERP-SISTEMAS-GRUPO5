using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers.API
{
    /// <summary>
    /// Controlador API para gestionar pedidos.
    /// Permite operaciones de lectura (GET), creación (POST),
    /// actualización parcial (PATCH) y eliminación (DELETE).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // Caso de uso de pedido inyectado por dependencias
        private readonly IPedidoUseCase _pedidoUseCase;

        /// <summary>
        /// Constructor del controlador de pedidos.
        /// </summary>
        /// <param name="pedidoUseCase">Caso de uso de pedido</param>
        public PedidoController(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de pedidos.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        // GET: api/Pedido
        [HttpGet]
        public IActionResult GetListaPedidos()
        {
            try
            {
                List<Pedido> pedidos = _pedidoUseCase.GetListaPedidos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener la lista de pedidos: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a buscar</param>
        /// <returns>Pedido encontrado o 404 si no existe</returns>
        // GET: api/Pedido/5
        [HttpGet("{idPedido}")]
        public IActionResult GetPedidoPorId(int idPedido)
        {
            try
            {
                Pedido pedido = _pedidoUseCase.GetPedidoPorId(idPedido);
                if (pedido == null) return NotFound();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener el pedido: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene la lista de pedidos realizados por un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de pedidos del usuario</returns>
        // GET: api/Pedido/usuario/5
        [HttpGet("usuario/{idUsuario}")]
        public IActionResult GetListaPedidosPorUsuario(int idUsuario)
        {
            try
            {
                List<Pedido> pedidos = _pedidoUseCase.GetListaPedidosPorUsuario(idUsuario);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener los pedidos del usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene la lista de pedidos asociados a un proveedor.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <returns>Lista de pedidos del proveedor</returns>
        // GET: api/Pedido/proveedor/5
        [HttpGet("proveedor/{idProveedor}")]
        public IActionResult GetListaPedidosPorProveedor(int idProveedor)
        {
            try
            {
                List<Pedido> pedidos = _pedidoUseCase.GetListaPedidosPorProveedor(idProveedor);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al obtener los pedidos del proveedor: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un nuevo pedido.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>201 si se creó correctamente, 400 si hubo error</returns>
        // POST: api/Pedido
        [HttpPost]
        public IActionResult CrearPedido([FromBody] CrearPedidoDto pedidoNuevo)
        {
            try
            {
                if (pedidoNuevo == null) return BadRequest("Pedido vacío.");
                int resultado = _pedidoUseCase.CrearPedido(pedidoNuevo);
                if (resultado == 0) return BadRequest("No se pudo crear el pedido.");
                return Created("", pedidoNuevo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al crear el pedido: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>200 si se actualizó, 404 si no se encontró</returns>
        // PATCH: api/Pedido/5
        [HttpPatch("{idPedido}")]
        public IActionResult ActualizarPedido(int idPedido, [FromBody] Pedido pedido)
        {
            try
            {
                if (pedido == null) return BadRequest("Pedido vacío.");
                int resultado = _pedidoUseCase.ActualizarPedido(idPedido, pedido);
                if (resultado == 0) return NotFound();
                if (resultado == -1) return BadRequest("El pedido no se puede modificar porque ya fue enviado o entregado.");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al actualizar el pedido: {ex.Message}");
            }
        }

        /// <summary>
        /// Cambia el estado de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado (pedido/enviado/entregado)</param>
        /// <returns>200 si se cambió, 404 si no se encontró</returns>
        // PATCH: api/Pedido/5/estado/enviado
        [HttpPatch("{idPedido}/estado/{nuevoEstado}")]
        public IActionResult CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            try
            {
                int resultado = _pedidoUseCase.CambiarEstadoPedido(idPedido, nuevoEstado);
                if (resultado == 0) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al cambiar el estado del pedido: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina (archiva) un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>200 si se eliminó, 404 si no se encontró</returns>
        // DELETE: api/Pedido/5
        [HttpDelete("{idPedido}")]
        public IActionResult EliminarPedido(int idPedido)
        {
            try
            {
                int resultado = _pedidoUseCase.EliminarPedido(idPedido);
                if (resultado == 0) return NotFound();
                if (resultado == -1) return BadRequest("El pedido ya está archivado.");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al eliminar el pedido: {ex.Message}");
            }
        }
    }
}