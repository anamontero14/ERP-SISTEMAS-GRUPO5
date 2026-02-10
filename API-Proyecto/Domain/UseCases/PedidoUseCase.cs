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
            pedidoNuevo.setArchivado(false);
            return _pedidoRepository.CrearPedido(pedidoNuevo);
        }

        public int ActualizarPedido(int idPedido, Pedido pedido)
        {
            Pedido pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                return 0;
            }

            if (pedidoActual.getEstado() != "entregado")
            {
                return 0;
            }

            // Actualizamos solo los campos modificables
            pedido.setIdUsuario(pedido.getIdUsuario());
            pedido.setIdProveedor(pedido.getIdProveedor());
            pedido.setFechaPedido(pedido.getFechaPedido());
            pedido.setEstado(pedido.getEstado());
            pedido.setObservaciones(pedido.getObservaciones());
            pedido.setArchivado(pedido.getArchivado());

            return _pedidoRepository.ActualizarPedido(idPedido, pedido);
        }

        public int CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            Pedido pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                return 0;
            }

            pedidoActual.setEstado(nuevoEstado);
            return _pedidoRepository.CambiarEstadoPedido(idPedido, nuevoEstado);
        }

        public int EliminarPedido(int idPedido)
        {
            Pedido pedidoActual = _pedidoRepository.GetPedidoPorId(idPedido);

            if (pedidoActual == null)
            {
                return 0;
            }

            if (pedidoActual.getEstado() != "entregado")
            {
                return 0;
            }

            // Soft delete: solo actualizamos el campo "archivado"
            pedidoActual.setArchivado(true);
            return _pedidoRepository.EliminarPedido(idPedido);
        }
    }
}
