using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;

namespace UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para la gestión de detalles de pedidos.
    /// Actúa como intermediario entre la capa de presentación y el repositorio.
    /// </summary>
    public class DetallePedidoUseCase : IDetallesPedidoUseCase
    {
        private readonly IDetallesPedidoRepository _detallePedidoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        /// <summary>
        /// Constructor del caso de uso DetallePedido.
        /// </summary>
        /// <param name="detallePedidoRepository">Repositorio de detalles de pedido</param>
        /// <param name="pedidoRepository">Repositorio de pedidos</param>
        public DetallePedidoUseCase(IDetallesPedidoRepository detallePedidoRepository, IPedidoRepository pedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
            _pedidoRepository = pedidoRepository;
        }

        /// <summary>
        /// Obtiene la lista de detalles de un pedido específico.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <returns>Lista de detalles del pedido</returns>
        public List<DetallePedido> GetListaDetallesPorPedido(int idPedido)
        {
            return _detallePedidoRepository.GetListaDetallesPorPedido(idPedido);
        }

        /// <summary>
        /// Obtiene todos los detalles de pedidos activos (no archivados).
        /// </summary>
        /// <returns>Lista de detalles de pedidos activos</returns>
        public List<DetallePedido> GetListaDetallesPedidosActivos()
        {
            return _detallePedidoRepository.GetListaDetallesPedidosActivos();
        }

        /// <summary>
        /// Obtiene un detalle de pedido específico por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Detalle del pedido encontrado</returns>
        public DetallePedido GetDetallePedidoPorId(int idPedido, int idProducto)
        {
            return _detallePedidoRepository.GetDetallePedidoPorId(idPedido, idProducto);
        }

        /// <summary>
        /// Crea un nuevo detalle de pedido en el sistema.
        /// </summary>
        /// <param name="detallePedidoNuevo">Detalle de pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int CrearDetallePedido(DetallePedido detallePedidoNuevo)
        {
            return _detallePedidoRepository.CrearDetallePedido(detallePedidoNuevo);
        }

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// Solo permite actualizar si el pedido está en estado "pedido".
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>1 si se actualizó, 0 si no existe, -1 si el estado no permite actualizar</returns>
        public int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido)
        {
            int resultado;
            Pedido? pedido = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedido == null)
            {
                resultado = 0;
            }
            else if (pedido.Estado != "pedido")
            {
                resultado = -1;
            }
            else
            {
                resultado = _detallePedidoRepository.ActualizarDetallePedido(idPedido, idProducto, detallePedido);
            }

            return resultado;
        }
    }
}