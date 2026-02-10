using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    public interface IDetallesPedidoUseCase
    {
        List<DetallePedido> GetListaDetallesPorPedido(int idPedido);
        DetallePedido GetDetallePedidoPorId(int idPedido, int idProducto);
        int CrearDetallePedido(DetallePedido detallePedidoNuevo);
        int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido);
        int EliminarDetallePedido(int idPedido, int idProducto);
    }
}
