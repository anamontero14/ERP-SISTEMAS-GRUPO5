using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define las operaciones del repositorio de DetallePedido.
    /// </summary>
    public interface IDetallesPedidoRepository
    {
        /// <summary>
        /// Obtiene la lista de detalles de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <returns>Lista de detalles del pedido</returns>
        List<DetallePedido> GetListaDetallesPorPedido(int idPedido);

        /// <summary>
        /// Obtiene todos los detalles de pedidos activos (no archivados).
        /// </summary>
        /// <returns>Lista de detalles de pedidos activos</returns>
        List<DetallePedido> GetListaDetallesPedidosActivos();

        /// <summary>
        /// Obtiene un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Detalle del pedido encontrado o null si no existe</returns>
        DetallePedido? GetDetallePedidoPorId(int idPedido, int idProducto);

        /// <summary>
        /// Crea un nuevo detalle de pedido.
        /// </summary>
        /// <param name="detallePedidoNuevo">Detalle de pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        int CrearDetallePedido(DetallePedido detallePedidoNuevo);

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>Número de filas afectadas</returns>
        int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido);

        /// <summary>
        /// Elimina un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Número de filas afectadas</returns>
        int EliminarDetallePedido(int idPedido, int idProducto);
    }
}