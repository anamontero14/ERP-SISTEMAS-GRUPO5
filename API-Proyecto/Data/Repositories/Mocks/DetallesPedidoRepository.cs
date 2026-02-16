/*using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio de DetallePedido con datos mock en memoria.
    /// Implementa la interfaz IDetallesPedidoRepository.
    /// </summary>
    public class DetallesPedidoRepository : IDetallesPedidoRepository
    {
        // Lista estática en memoria que simula la tabla DETALLE_PEDIDO
        private static List<DetallePedido> listaDetalles = new List<DetallePedido>
        {
            new DetallePedido(1, 1, 100, 2.50m),
            new DetallePedido(1, 2, 5, 12.99m),
            new DetallePedido(2, 3, 2, 89.95m),
            new DetallePedido(3, 4, 10, 5.75m),
            new DetallePedido(4, 5, 3, 65.00m)
        };

        /// <summary>
        /// Obtiene la lista de detalles de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <returns>Lista de detalles del pedido</returns>
        public List<DetallePedido> GetListaDetallesPorPedido(int idPedido)
        {
            return listaDetalles.Where(d => d.getIdPedido() == idPedido).ToList();
        }

        /// <summary>
        /// Obtiene un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Detalle del pedido encontrado o null si no existe</returns>
        public DetallePedido GetDetallePedidoPorId(int idPedido, int idProducto)
        {
            return listaDetalles.FirstOrDefault(d => d.getIdPedido() == idPedido && d.getIdProducto() == idProducto);
        }

        /// <summary>
        /// Crea un nuevo detalle de pedido.
        /// </summary>
        /// <param name="detallePedidoNuevo">Detalle de pedido a crear</param>
        /// <returns>1 si se creó correctamente, 0 en caso contrario</returns>
        public int CrearDetallePedido(DetallePedido detallePedidoNuevo)
        {
            DetallePedido detalleExistente = listaDetalles.FirstOrDefault(
                d => d.getIdPedido() == detallePedidoNuevo.getIdPedido() && d.getIdProducto() == detallePedidoNuevo.getIdProducto()
            );
            if (detalleExistente != null) return 0;

            listaDetalles.Add(detallePedidoNuevo);
            return 1;
        }

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>1 si se actualizó correctamente, 0 si no se encontró</returns>
        public int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido)
        {
            DetallePedido detalleExistente = listaDetalles.FirstOrDefault(
                d => d.getIdPedido() == idPedido && d.getIdProducto() == idProducto
            );
            if (detalleExistente == null) return 0;

            detalleExistente.setCantidad(detallePedido.getCantidad());
            detalleExistente.setPrecioUnitario(detallePedido.getPrecioUnitario());
            return 1;
        }

        /// <summary>
        /// Elimina un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>1 si se eliminó correctamente, 0 si no se encontró</returns>
        public int EliminarDetallePedido(int idPedido, int idProducto)
        {
            DetallePedido detalle = listaDetalles.FirstOrDefault(
                d => d.getIdPedido() == idPedido && d.getIdProducto() == idProducto
            );
            if (detalle == null) return 0;

            listaDetalles.Remove(detalle);
            return 1;
        }
    }
}*/
