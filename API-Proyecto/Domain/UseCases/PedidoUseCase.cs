using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System;
using System.Collections.Generic;

namespace UseCases
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public List<Pedido> GetListaPedidos()
        {
            return _pedidoRepository.GetListaPedidos();
        }

        public List<Pedido> GetListaPedidosPorUsuario(int idUsuario)
        {
            return _pedidoRepository.GetListaPedidosPorUsuario(idUsuario);
        }

        public List<Pedido> GetListaPedidosPorProveedor(int idProveedor)
        {
            return _pedidoRepository.GetListaPedidosPorProveedor(idProveedor);
        }

        public Pedido GetPedidoPorId(int idPedido)
        {
            return _pedidoRepository.GetPedidoPorId(idPedido);
        }

        public int CrearPedido(Pedido pedidoNuevo)
        {
            pedidoNuevo.Archivado = false;
            return _pedidoRepository.CrearPedido(pedidoNuevo);
        }

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