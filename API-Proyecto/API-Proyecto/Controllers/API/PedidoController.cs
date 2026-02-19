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
        /// <summary>
        /// Atributo que almacena el caso de uso para poder usar sus métodos
        /// </summary>
        private readonly IPedidoUseCase _pedidoUseCase;

        /// <summary>
        /// Inyección del caso de uso de pedidos
        /// </summary>
        /// <param name="pedidoUseCase">Caso de uso de pedido</param>
        public PedidoController(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        /// <summary>
        /// Obtiene la lista completa de pedidos llamando al caso de uso.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        // GET: api/Pedido
        [HttpGet]
        public IActionResult GetListaPedidos()
        {
            IActionResult resultado;
            try
            {
                List<Pedido> pedidos = _pedidoUseCase.GetListaPedidos();
                resultado = Ok(pedidos);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener la lista de pedidos: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene un pedido por su identificador llamando al caso de uso.
        /// Si no se encuentra el pedido, devuelve 404.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idPedido">ID del pedido a buscar</param>
        /// <returns>Pedido encontrado o 404 si no existe</returns>
        // GET: api/Pedido/5
        [HttpGet("{idPedido}")]
        public IActionResult GetPedidoPorId(int idPedido)
        {
            IActionResult resultado;
            try
            {
                Pedido pedido = _pedidoUseCase.GetPedidoPorId(idPedido);
                resultado = pedido == null ? NotFound() : Ok(pedido);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener el pedido: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene la lista de pedidos realizados por un usuario dado su identificador.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de pedidos del usuario</returns>
        // GET: api/Pedido/usuario/5
        [HttpGet("usuario/{idUsuario}")]
        public IActionResult GetListaPedidosPorUsuario(int idUsuario)
        {
            IActionResult resultado;
            try
            {
                List<Pedido> pedidos = _pedidoUseCase.GetListaPedidosPorUsuario(idUsuario);
                resultado = Ok(pedidos);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener los pedidos del usuario: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene la lista de pedidos asociados a un proveedor dado su identificador.
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <returns>Lista de pedidos del proveedor</returns>
        // GET: api/Pedido/proveedor/5
        [HttpGet("proveedor/{idProveedor}")]
        public IActionResult GetListaPedidosPorProveedor(int idProveedor)
        {
            IActionResult resultado;
            try
            {
                List<Pedido> pedidos = _pedidoUseCase.GetListaPedidosPorProveedor(idProveedor);
                resultado = Ok(pedidos);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al obtener los pedidos del proveedor: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Crea un nuevo pedido a partir del DTO recibido en el cuerpo de la petición.
        /// Si el DTO es nulo, devuelve 400.
        /// Si el caso de uso devuelve 0, no se pudo crear el pedido (400).
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="pedidoNuevo">Datos del pedido a crear</param>
        /// <returns>201 si se creó correctamente, 400 si hubo un error de validación</returns>
        // POST: api/Pedido
        [HttpPost]
        public IActionResult CrearPedido([FromBody] CrearPedidoDto pedidoNuevo)
        {
            IActionResult resultado;
            try
            {
                if (pedidoNuevo == null)
                {
                    resultado = BadRequest("Pedido vacío.");
                }
                else
                {
                    int codigoResultado = _pedidoUseCase.CrearPedido(pedidoNuevo);
                    resultado = codigoResultado == 0
                        ? BadRequest("No se pudo crear el pedido.")
                        : Created("", pedidoNuevo);
                }
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al crear el pedido: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Actualiza un pedido existente identificado por su id.
        /// Si el objeto pedido es nulo, devuelve 400.
        /// Si el caso de uso devuelve 0, el pedido no fue encontrado (404).
        /// Si devuelve -1, el pedido ya fue enviado o entregado y no puede modificarse (400).
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>200 si se actualizó, 404 si no se encontró, 400 si el estado no lo permite</returns>
        // PATCH: api/Pedido/5
        [HttpPatch("{idPedido}")]
        public IActionResult ActualizarPedido(int idPedido, [FromBody] Pedido pedido)
        {
            IActionResult resultado;
            try
            {
                if (pedido == null)
                {
                    resultado = BadRequest("Pedido vacío.");
                }
                else
                {
                    int codigoResultado = _pedidoUseCase.ActualizarPedido(idPedido, pedido);
                    if (codigoResultado == 0)
                        resultado = NotFound();
                    else if (codigoResultado == -1)
                        resultado = BadRequest("El pedido no se puede modificar porque ya fue enviado o entregado.");
                    else
                        resultado = Ok();
                }
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al actualizar el pedido: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Cambia el estado de un pedido dado su identificador y el nuevo estado deseado.
        /// Si el caso de uso devuelve 0, el pedido no fue encontrado (404).
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado (pedido/enviado/entregado)</param>
        /// <returns>200 si se cambió el estado, 404 si no se encontró</returns>
        // PATCH: api/Pedido/5/estado/enviado
        [HttpPatch("{idPedido}/estado/{nuevoEstado}")]
        public IActionResult CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            IActionResult resultado;
            try
            {
                int codigoResultado = _pedidoUseCase.CambiarEstadoPedido(idPedido, nuevoEstado);
                resultado = codigoResultado == 0 ? NotFound() : Ok();
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al cambiar el estado del pedido: {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Elimina (archiva) un pedido dado su identificador.
        /// Si el caso de uso devuelve 0, el pedido no fue encontrado (404).
        /// Si devuelve -1, el pedido ya está archivado (400).
        /// Si ocurre una excepción, devuelve un error 500.
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>200 si se eliminó, 404 si no se encontró, 400 si ya estaba archivado</returns>
        // DELETE: api/Pedido/5
        [HttpDelete("{idPedido}")]
        public IActionResult EliminarPedido(int idPedido)
        {
            IActionResult resultado;
            try
            {
                int codigoResultado = _pedidoUseCase.EliminarPedido(idPedido);
                if (codigoResultado == 0)
                    resultado = NotFound();
                else if (codigoResultado == -1)
                    resultado = BadRequest("El pedido ya está archivado.");
                else
                    resultado = Ok();
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, $"Error interno al eliminar el pedido: {ex.Message}");
            }
            return resultado;
        }
    }
}