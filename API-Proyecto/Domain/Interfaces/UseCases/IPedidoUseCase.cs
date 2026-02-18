using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    /// <summary>
    /// Interfaz que define las operaciones del caso de uso de Pedido.
    /// </summary>
    public interface IPedidoUseCase
    {
        /// <summary>
        /// Obtiene la lista completa de pedidos.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        List<Pedido> GetListaPedidos();

        /// <summary>
        /// Obtiene la lista de pedidos realizados por un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de pedidos del usuario</returns>
        List<Pedido> GetListaPedidosPorUsuario(int idUsuario);

        /// <summary>
        /// Obtiene la lista de pedidos asociados a un proveedor.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <returns>Lista de pedidos del proveedor</returns>
        List<Pedido> GetListaPedidosPorProveedor(int idProveedor);

        /// <summary>
        /// Obtiene un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a buscar</param>
        /// <returns>Pedido encontrado</returns>
        Pedido GetPedidoPorId(int idPedido);

        /// <summary>
        /// Crea un nuevo pedido.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        int CrearPedido(CrearPedidoDto pedidoNuevo);

        /// <summary>
        /// Actualiza un pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>Número de filas afectadas</returns>
        int ActualizarPedido(int idPedido, Pedido pedido);

        /// <summary>
        /// Cambia el estado de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado del pedido</param>
        /// <returns>Número de filas afectadas</returns>
        int CambiarEstadoPedido(int idPedido, string nuevoEstado);

        /// <summary>
        /// Elimina un pedido (actualiza campo Archivado a true).
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        int EliminarPedido(int idPedido);
    }
}