using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    /// <summary>
    /// Interfaz que define las operaciones del caso de uso de DetallePedido.
    /// </summary>
    public interface IDetallesPedidoUseCase
    {
        /// <summary>
        /// Obtiene la lista de detalles de un pedido específico.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <returns>Lista de detalles del pedido</returns>
        List<DetallePedido> GetListaDetallesPorPedido(int idPedido);

        /// <summary>
        /// Obtiene un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Detalle del pedido encontrado</returns>
        DetallePedido GetDetallePedidoPorId(int idPedido, int idProducto);

        /// <summary>
        /// Crea un nuevo detalle de pedido.
        /// </summary>
        /// <param name="detallePedidoNuevo">Detalle de pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        int CrearDetallePedido(DetallePedido detallePedidoNuevo);

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>Número de filas afectadas</returns>
        int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido);
    }
}