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
            List<Pedido> pedidos = _pedidoUseCase.GetListaPedidos();
            return Ok(pedidos);
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
            Pedido pedido = _pedidoUseCase.GetPedidoPorId(idPedido);
            if (pedido == null) return NotFound();
            return Ok(pedido);
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
            List<Pedido> pedidos = _pedidoUseCase.GetListaPedidosPorUsuario(idUsuario);
            return Ok(pedidos);
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
            List<Pedido> pedidos = _pedidoUseCase.GetListaPedidosPorProveedor(idProveedor);
            return Ok(pedidos);
        }

        /// <summary>
        /// Crea un nuevo pedido.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>201 si se creó correctamente</returns>
        // POST: api/Pedido
        [HttpPost]
        public IActionResult CrearPedido([FromBody] Pedido pedidoNuevo)
        {
            int resultado = _pedidoUseCase.CrearPedido(pedidoNuevo);
            if (resultado == 0) return BadRequest();
            return Created("", pedidoNuevo);
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
            int resultado = _pedidoUseCase.ActualizarPedido(idPedido, pedido);
            if (resultado == 0) return NotFound();
            return Ok();
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
            int resultado = _pedidoUseCase.CambiarEstadoPedido(idPedido, nuevoEstado);
            if (resultado == 0) return NotFound();
            return Ok();
        }

        /// <summary>
        /// Elimina un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>200 si se eliminó, 404 si no se encontró</returns>
        // DELETE: api/Pedido/5
        [HttpDelete("{idPedido}")]
        public IActionResult EliminarPedido(int idPedido)
        {
            int resultado = _pedidoUseCase.EliminarPedido(idPedido);
            if (resultado == 0) return NotFound();
            return Ok();
        }
    }
}