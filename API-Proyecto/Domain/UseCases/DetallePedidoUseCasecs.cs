using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;

namespace UseCases
{
    public class DetallePedidoUseCase : IDetallesPedidoUseCase
    {
        private readonly IDetallesPedidoRepository _detallePedidoRepository;

        public DetallePedidoUseCase(IDetallesPedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        public List<DetallePedido> GetListaDetallesPorPedido(int idPedido)
        {
            return _detallePedidoRepository.GetListaDetallesPorPedido(idPedido);
        }

        public DetallePedido GetDetallePedidoPorId(int idPedido, int idProducto)
        {
            return _detallePedidoRepository.GetDetallePedidoPorId(idPedido, idProducto);
        }

        public int CrearDetallePedido(DetallePedido detallePedidoNuevo)
        {
            return _detallePedidoRepository.CrearDetallePedido(detallePedidoNuevo);
        }

        public int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido)
        {
            return _detallePedidoRepository.ActualizarDetallePedido(idPedido, idProducto, detallePedido);
        }

        public int EliminarDetallePedido(int idPedido, int idProducto)
        {
            return _detallePedidoRepository.EliminarDetallePedido(idPedido, idProducto);
        }
    }
}
