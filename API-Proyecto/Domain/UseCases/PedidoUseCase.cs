using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System;
using System.Collections.Generic;

namespace UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para la gestión de pedidos.
    /// Incluye validaciones y reglas de negocio antes de delegar al repositorio.
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
        /// <returns>Pedido encontrado</returns>
        public Pedido GetPedidoPorId(int idPedido)
        {
            return _pedidoRepository.GetPedidoPorId(idPedido);
        }

        /// <summary>
        /// Crea un nuevo pedido en el sistema.
        /// Inicializa el campo Archivado como false automáticamente.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int CrearPedido(Pedido pedidoNuevo)
        {
            pedidoNuevo.Archivado = false;
            return _pedidoRepository.CrearPedido(pedidoNuevo);
        }

        /// <summary>
        /// Actualiza un pedido existente.
        /// Solo permite actualizar pedidos que no estén en estado "entregado".
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>Número de filas afectadas, 0 si el pedido no existe o está entregado</returns>
        public int ActualizarPedido(int idPedido, Pedido pedido)
        {
            Pedido pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                return 0;
            }

            if (pedidoActual.Estado != "entregado")
            {
                return 0;
            }

            // Actualizamos solo los campos modificables
            pedido.IdUsuario = pedido.IdUsuario;
            pedido.IdProveedor = pedido.IdProveedor;
            pedido.FechaPedido = pedido.FechaPedido;
            pedido.Estado = pedido.Estado;
            pedido.Observaciones = pedido.Observaciones;
            pedido.Archivado = pedido.Archivado;

            return _pedidoRepository.ActualizarPedido(idPedido, pedido);
        }

        /// <summary>
        /// Cambia el estado de un pedido específico.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado del pedido</param>
        /// <returns>Número de filas afectadas, 0 si el pedido no existe</returns>
        public int CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            Pedido pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                return 0;
            }

            pedidoActual.Estado = nuevoEstado;
            return _pedidoRepository.CambiarEstadoPedido(idPedido, nuevoEstado);
        }

        /// <summary>
        /// Elimina (archiva) un pedido del sistema mediante soft delete.
        /// Solo permite eliminar pedidos que no estén en estado "entregado".
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>Número de filas afectadas, 0 si el pedido no existe o está entregado</returns>
        public int EliminarPedido(int idPedido)
        {
            Pedido pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                return 0;
            }

            if (pedidoActual.Estado != "entregado")
            {
                return 0;
            }

            // Soft delete: solo actualizamos el campo "archivado"
            pedidoActual.Archivado = true;
            return _pedidoRepository.EliminarPedido(idPedido);
        }
    }
}