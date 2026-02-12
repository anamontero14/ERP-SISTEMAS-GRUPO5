using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio de Pedido con datos mock en memoria.
    /// Implementa la interfaz IPedidoRepository.
    /// </summary>
    public class PedidoRepository : IPedidoRepository
    {
        // Lista estática en memoria que simula la tabla PEDIDO
        private static List<Pedido> listaPedidos = new List<Pedido>
        {
            new Pedido(1, 1, 1, new DateTime(2025, 1, 15), "pedido", "Pedido urgente de tornillos", false),
            new Pedido(2, 1, 2, new DateTime(2025, 1, 20), "enviado", "Herramientas para taller", false),
            new Pedido(3, 2, 3, new DateTime(2025, 2, 1), "entregado", "Material de construcción", false),
            new Pedido(4, 2, 4, new DateTime(2025, 2, 5), "pedido", "Suministros de oficina", true),
            new Pedido(5, 3, 5, new DateTime(2025, 2, 8), "enviado", "Repuestos de maquinaria", false)
        };

        // Contador para generar IDs automáticamente
        private static int contadorId = 6;

        /// <summary>
        /// Obtiene la lista completa de pedidos.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        public List<Pedido> GetListaPedidos()
        {
            return listaPedidos;
        }

        /// <summary>
        /// Obtiene la lista de pedidos realizados por un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de pedidos del usuario</returns>
        public List<Pedido> GetListaPedidosPorUsuario(int idUsuario)
        {
            return listaPedidos.Where(p => p.getIdUsuario() == idUsuario).ToList();
        }

        /// <summary>
        /// Obtiene la lista de pedidos asociados a un proveedor.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <returns>Lista de pedidos del proveedor</returns>
        public List<Pedido> GetListaPedidosPorProveedor(int idProveedor)
        {
            return listaPedidos.Where(p => p.getIdProveedor() == idProveedor).ToList();
        }

        /// <summary>
        /// Obtiene un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a buscar</param>
        /// <returns>Pedido encontrado o null si no existe</returns>
        public Pedido GetPedidoPorId(int idPedido)
        {
            return listaPedidos.FirstOrDefault(p => p.getIdPedido() == idPedido);
        }

        /// <summary>
        /// Crea un nuevo pedido.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>1 si se creó correctamente, 0 en caso contrario</returns>
        public int CrearPedido(Pedido pedidoNuevo)
        {
            Pedido pedido = new Pedido(
                contadorId++,
                pedidoNuevo.getIdUsuario(),
                pedidoNuevo.getIdProveedor(),
                pedidoNuevo.getFechaPedido(),
                pedidoNuevo.getEstado(),
                pedidoNuevo.getObservaciones(),
                pedidoNuevo.getArchivado()
            );
            listaPedidos.Add(pedido);
            return 1;
        }

        /// <summary>
        /// Actualiza un pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>1 si se actualizó correctamente, 0 si no se encontró</returns>
        public int ActualizarPedido(int idPedido, Pedido pedido)
        {
            Pedido pedidoExistente = listaPedidos.FirstOrDefault(p => p.getIdPedido() == idPedido);
            if (pedidoExistente == null) return 0;

            pedidoExistente.setIdUsuario(pedido.getIdUsuario());
            pedidoExistente.setIdProveedor(pedido.getIdProveedor());
            pedidoExistente.setFechaPedido(pedido.getFechaPedido());
            pedidoExistente.setEstado(pedido.getEstado());
            pedidoExistente.setObservaciones(pedido.getObservaciones());
            return 1;
        }

        /// <summary>
        /// Cambia el estado de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado (pedido/enviado/entregado)</param>
        /// <returns>1 si se cambió correctamente, 0 si no se encontró</returns>
        public int CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            Pedido pedido = listaPedidos.FirstOrDefault(p => p.getIdPedido() == idPedido);
            if (pedido == null) return 0;

            pedido.setEstado(nuevoEstado);
            return 1;
        }

        /// <summary>
        /// Elimina un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>1 si se eliminó correctamente, 0 si no se encontró</returns>
        public int EliminarPedido(int idPedido)
        {
            Pedido pedido = listaPedidos.FirstOrDefault(p => p.getIdPedido() == idPedido);
            if (pedido == null) return 0;

            listaPedidos.Remove(pedido);
            return 1;
        }
    }
}
