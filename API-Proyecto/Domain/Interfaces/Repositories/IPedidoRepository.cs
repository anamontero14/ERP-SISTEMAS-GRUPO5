using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define las operaciones del repositorio de Pedido.
    /// </summary>
    public interface IPedidoRepository
    {
        /// <summary>
        /// Obtiene la lista completa de pedidos.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        List<Pedido> GetListaPedidos();

        /// <summary>
        /// Obtiene la lista de pedidos realizados por un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de pedidos del usuario</returns>
        List<Pedido> GetListaPedidosPorUsuario(int idUsuario);

        /// <summary>
        /// Obtiene la lista de pedidos asociados a un proveedor.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <returns>Lista de pedidos del proveedor</returns>
        List<Pedido> GetListaPedidosPorProveedor(int idProveedor);

        /// <summary>
        /// Obtiene un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a buscar</param>
        /// <returns>Pedido encontrado o null si no existe</returns>
        Pedido? GetPedidoPorId(int idPedido);

        /// <summary>
        /// Crea un nuevo pedido.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        int CrearPedido(Pedido pedidoNuevo);

        /// <summary>
        /// Actualiza un pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>Número de filas afectadas</returns>
        int ActualizarPedido(int idPedido, Pedido pedido);

        /// <summary>
        /// Cambia el estado de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado (pedido/enviado/entregado)</param>
        /// <returns>Número de filas afectadas</returns>
        int CambiarEstadoPedido(int idPedido, string nuevoEstado);

        /// <summary>
        /// Elimina un pedido por su identificador (actualiza campo Archivado a true).
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        int EliminarPedido(int idPedido);
    }
}