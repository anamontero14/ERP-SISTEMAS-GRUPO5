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

        /// <summary>
        /// Constructor del caso de uso Pedido.
        /// </summary>
        /// <param name="pedidoRepository">Repositorio de pedidos</param>
        public PedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
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
        /// Crea un nuevo pedido en el sistema.
        /// Inicializa el estado como "pedido" y Archivado como false automáticamente.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int CrearPedido(Pedido pedidoNuevo)
        {
            pedidoNuevo.Estado = "pedido";
            pedidoNuevo.Archivado = false;
            return _pedidoRepository.CrearPedido(pedidoNuevo);
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
            Pedido? pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null) return 0;

            // Solo se puede actualizar si el estado es "pedido"
            if (pedidoActual.Estado != "pedido") return -1;

            return _pedidoRepository.ActualizarPedido(idPedido, pedido);
        }

        /// <summary>
        /// Cambia el estado de un pedido específico.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado del pedido</param>
        /// <returns>1 si se cambió, 0 si no existe</returns>
        public int CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            Pedido? pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null) return 0;

            return _pedidoRepository.CambiarEstadoPedido(idPedido, nuevoEstado);
        }

        /// <summary>
        /// Archiva un pedido del sistema (soft delete).
        /// No se puede archivar un pedido que ya esté archivado.
        /// </summary>
        /// <param name="idPedido">ID del pedido a archivar</param>
        /// <returns>1 si se archivó, 0 si no existe, -1 si ya estaba archivado</returns>
        public int EliminarPedido(int idPedido)
        {
            Pedido? pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null) return 0;

            // No se puede archivar un pedido que ya está archivado
            if (pedidoActual.Archivado) return -1;

            return _pedidoRepository.EliminarPedido(idPedido);
        }
    }
}