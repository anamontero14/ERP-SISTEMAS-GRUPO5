using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    public interface IPedidoUseCase
    {
        List<Pedido> GetListaPedidos();
        List<Pedido> GetListaPedidosPorUsuario(int idUsuario);
        List<Pedido> GetListaPedidosPorProveedor(int idProveedor);
        Pedido GetPedidoPorId(int idPedido);
        int CrearPedido(Pedido pedidoNuevo);
        int ActualizarPedido(int idPedido, Pedido pedido);
        int CambiarEstadoPedido(int idPedido, string nuevoEstado);
        int EliminarPedido(int idPedido);
    }
}
