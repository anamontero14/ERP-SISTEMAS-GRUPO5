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

        /// <summary>
        /// Constructor del caso de uso DetallePedido.
        /// </summary>
        /// <param name="detallePedidoRepository">Repositorio de detalles de pedido</param>
        public DetallePedidoUseCase(IDetallesPedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
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
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>Número de filas afectadas</returns>
        public int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido)
        {
            return _detallePedidoRepository.ActualizarDetallePedido(idPedido, idProducto, detallePedido);
        }

        /// <summary>
        /// Elimina un detalle de pedido del sistema.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Número de filas afectadas</returns>
        public int EliminarDetallePedido(int idPedido, int idProducto)
        {
            return _detallePedidoRepository.EliminarDetallePedido(idPedido, idProducto);
        }
    }
}