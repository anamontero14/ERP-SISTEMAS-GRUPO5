using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para la gestión de pedidos.
    /// </summary>
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IDetallesPedidoRepository _detallesPedidoRepository;

        /// <summary>
        /// Constructor del caso de uso Pedido.
        /// </summary>
        /// <param name="pedidoRepository">Repositorio de pedidos</param>
        /// <param name="detallesPedidoRepository">Repositorio de detalles de pedido</param>
        public PedidoUseCase(IPedidoRepository pedidoRepository, IDetallesPedidoRepository detallesPedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _detallesPedidoRepository = detallesPedidoRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de pedidos del sistema.
        /// </summary>
        /// <returns>Lista de todos los pedidos</returns>
        public List<Pedido> GetListaPedidos()
        {
            return _pedidoRepository.GetListaPedidos();
        }

        /// <summary>
        /// Obtiene la lista de pedidos realizados por un usuario específico.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de pedidos del usuario</returns>
        public List<Pedido> GetListaPedidosPorUsuario(int idUsuario)
        {
            return _pedidoRepository.GetListaPedidosPorUsuario(idUsuario);
        }

        /// <summary>
        /// Obtiene la lista de pedidos asociados a un proveedor específico.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <returns>Lista de pedidos del proveedor</returns>
        public List<Pedido> GetListaPedidosPorProveedor(int idProveedor)
        {
            return _pedidoRepository.GetListaPedidosPorProveedor(idProveedor);
        }

        /// <summary>
        /// Obtiene un pedido específico por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a buscar</param>
        /// <returns>Pedido encontrado o null si no existe</returns>
        public Pedido? GetPedidoPorId(int idPedido)
        {
            return _pedidoRepository.GetPedidoPorId(idPedido);
        }

        /// <summary>
        /// Crea un nuevo pedido en el sistema junto con sus detalles.
        /// Inicializa el estado como "pedido" y Archivado como false automáticamente.
        /// </summary>
        /// <param name="dto">DTO con el pedido y sus detalles a crear</param>
        /// <returns>ID del pedido creado, 0 si hubo error</returns>
        public int CrearPedido(CrearPedidoDto dto)
        {
            dto.Pedido.Estado = "pedido";
            dto.Pedido.Archivado = false;

            int idPedido = _pedidoRepository.CrearPedidoYObtenerID(dto.Pedido);

            if (idPedido != 0)
            {
                foreach (var detalle in dto.Detalles)
                {
                    detalle.IdPedido = idPedido;
                    _detallesPedidoRepository.CrearDetallePedido(detalle);
                }
            }

            return idPedido;
        }

        /// <summary>
        /// Actualiza un pedido existente.
        /// Solo permite actualizar pedidos en estado "pedido".
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>1 si se actualizó, 0 si no existe, -1 si el estado no permite actualizar</returns>
        public int ActualizarPedido(int idPedido, Pedido pedido)
        {
            int resultado;
            Pedido? pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                resultado = 0;
            }
            else if (pedidoActual.Estado != "pedido")
            {
                resultado = -1;
            }
            else
            {
                resultado = _pedidoRepository.ActualizarPedido(idPedido, pedido);
            }

            return resultado;
        }

        /// <summary>
        /// Cambia el estado de un pedido específico.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado del pedido</param>
        /// <returns>1 si se cambió, 0 si no existe</returns>
        public int CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            int resultado;
            Pedido? pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                resultado = 0;
            }
            else
            {
                resultado = _pedidoRepository.CambiarEstadoPedido(idPedido, nuevoEstado);
            }

            return resultado;
        }

        /// <summary>
        /// Archiva un pedido del sistema (soft delete).
        /// No se puede archivar un pedido que ya esté archivado.
        /// </summary>
        /// <param name="idPedido">ID del pedido a archivar</param>
        /// <returns>1 si se archivó, 0 si no existe, -1 si ya estaba archivado</returns>
        public int EliminarPedido(int idPedido)
        {
            int resultado;
            Pedido? pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                resultado = 0;
            }
            else if (pedidoActual.Archivado)
            {
                resultado = -1;
            }
            else
            {
                resultado = _pedidoRepository.EliminarPedido(idPedido);
            }

            return resultado;
        }
    }
}