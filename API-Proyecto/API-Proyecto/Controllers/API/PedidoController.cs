using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetAll()
        {
            var lista = _pedidoRepository.GetListaPedidos();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Pedido> GetById(int id)
        {
            var pedido = _pedidoRepository.GetPedidoPorId(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpGet("usuario/{idUsuario:int}")]
        public ActionResult<IEnumerable<Pedido>> GetByUsuario(int idUsuario)
        {
            var lista = _pedidoRepository.GetListaPedidosPorUsuario(idUsuario);
            return Ok(lista);
        }

        [HttpGet("proveedor/{idProveedor:int}")]
        public ActionResult<IEnumerable<Pedido>> GetByProveedor(int idProveedor)
        {
            var lista = _pedidoRepository.GetListaPedidosPorProveedor(idProveedor);
            return Ok(lista);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Pedido pedidoNuevo)
        {
            if (pedidoNuevo == null) return BadRequest("Pedido vacío.");
            // Validaciones mínimas
            if (pedidoNuevo.IdUsuario <= 0) return BadRequest("IdUsuario inválido.");
            if (pedidoNuevo.IdProveedor <= 0) return BadRequest("IdProveedor inválido.");

            int filas = _pedidoRepository.CrearPedido(pedidoNuevo);
            if (filas > 0)
            {
                // Opcional: devolver la ruta al recurso creado
                return CreatedAtAction(nameof(GetById), new { id = pedidoNuevo.IdPedido }, pedidoNuevo);
            }
            return StatusCode(500, "No se pudo crear el pedido.");
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, [FromBody] Pedido pedido)
        {
            if (pedido == null) return BadRequest("Pedido vacío.");
            // Asegurarse de que el id coincide o asignarlo
            // pedido.IdPedido = id; // si quieres forzar el id
            int filas = _pedidoRepository.ActualizarPedido(id, pedido);
            if (filas > 0) return NoContent();
            return NotFound();
        }

        [HttpPatch("{id:int}/estado")]
        public ActionResult ChangeState(int id, [FromBody] string nuevoEstado)
        {
            if (string.IsNullOrWhiteSpace(nuevoEstado)) return BadRequest("Estado inválido.");
            int filas = _pedidoRepository.CambiarEstadoPedido(id, nuevoEstado);
            if (filas > 0) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            int filas = _pedidoRepository.EliminarPedido(id);
            if (filas > 0) return NoContent();
            return NotFound();
        }
    }
}
