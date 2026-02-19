using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    /// <summary>
    /// DTO (Data Transfer Object) que agrupa un pedido junto con su lista de detalles.
    /// Se utiliza para crear un pedido completo con sus productos en una sola petición.
    /// </summary>
    public class CrearPedidoDto
    {
        /// <summary>
        /// Datos del pedido a crear.
        /// </summary>
        public Pedido Pedido { get; set; }

        /// <summary>
        /// Lista de detalles (productos) asociados al pedido.
        /// </summary>
        public List<DetallePedido> Detalles { get; set; }
    }
}
