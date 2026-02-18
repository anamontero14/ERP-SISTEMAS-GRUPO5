using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CrearPedidoDto
    {
        public Pedido Pedido { get; set; }
        public List<DetallePedido> Detalles { get; set; }
    }
}
