using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories.AzureRepositories
{
    /// <summary>
    /// Repositorio de Pedido con conexión a Azure SQL.
    /// Implementa la interfaz IPedidoRepository.
    /// </summary>
    public class PedidoRepositoryAzure : IPedidoRepository
    {
        #region MÉTODOS AUXILIARES

        /// <summary>
        /// Obtiene un valor booleano de una columna del lector, manejando nulos.
        /// </summary>
        /// <param name="reader">Lector de datos SQL</param>
        /// <param name="column">Nombre de la columna</param>
        /// <returns>Valor booleano o false si es nulo</returns>
        private bool GetBool(SqlDataReader reader, string column)
        {
            return reader[column] != DBNull.Value && Convert.ToBoolean(reader[column]);
        }

        /// <summary>
        /// Obtiene un valor string de una columna del lector, manejando nulos.
        /// </summary>
        /// <param name="reader">Lector de datos SQL</param>
        /// <param name="column">Nombre de la columna</param>
        /// <returns>Valor string o cadena vacía si es nulo</returns>
        private string GetString(SqlDataReader reader, string column)
        {
            return reader[column] == DBNull.Value ? "" : reader[column].ToString()!;
        }

        /// <summary>
        /// Mapea una fila del lector SQL a un objeto Pedido.
        /// </summary>
        /// <param name="miLector">Lector de datos SQL posicionado en una fila</param>
        /// <returns>Objeto Pedido con los datos de la fila</returns>
        private Pedido MapPedido(SqlDataReader miLector)
        {
            return new Pedido
            {
                IdPedido = (int)miLector["idPedido"],
                IdUsuario = (int)miLector["idUsuario"],
                IdProveedor = (int)miLector["idProveedor"],
                FechaPedido = (DateTime)miLector["fechaPedido"],
                Estado = GetString(miLector, "estado"),
                Observaciones = GetString(miLector, "observaciones"),
                Archivado = GetBool(miLector, "archivado")
            };
        }

        #endregion

        #region MÉTODOS CRUD

        /// <summary>
        /// Obtiene la lista completa de pedidos.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        public List<Pedido> GetListaPedidos()
        {
            List<Pedido> listaPedidos = new();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO",
                    miConexion
                );

                miLector = miComando.ExecuteReader();

                while (miLector.Read())
                    listaPedidos.Add(MapPedido(miLector));
            }
            finally
            {
                miLector?.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return listaPedidos;
        }

        /// <summary>
        /// Obtiene la lista de pedidos realizados por un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de pedidos del usuario</returns>
        public List<Pedido> GetListaPedidosPorUsuario(int idUsuario)
        {
            List<Pedido> listaPedidos = new();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO WHERE idUsuario = @idUsuario",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idUsuario", idUsuario);

                miLector = miComando.ExecuteReader();

                while (miLector.Read())
                    listaPedidos.Add(MapPedido(miLector));
            }
            finally
            {
                miLector?.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return listaPedidos;
        }

        /// <summary>
        /// Obtiene la lista de pedidos asociados a un proveedor.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <returns>Lista de pedidos del proveedor</returns>
        public List<Pedido> GetListaPedidosPorProveedor(int idProveedor)
        {
            List<Pedido> listaPedidos = new();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO WHERE idProveedor = @idProveedor",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idProveedor", idProveedor);

                miLector = miComando.ExecuteReader();

                while (miLector.Read())
                    listaPedidos.Add(MapPedido(miLector));
            }
            finally
            {
                miLector?.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return listaPedidos;
        }

        /// <summary>
        /// Obtiene un pedido por su identificador.
        /// </summary>
        /// <param name="idPedido">ID del pedido a buscar</param>
        /// <returns>Pedido encontrado o null si no existe</returns>
        public Pedido? GetPedidoPorId(int idPedido)
        {
            Pedido? pedido = null;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO WHERE idPedido = @idPedido",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idPedido", idPedido);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                    pedido = MapPedido(miLector);
            }
            finally
            {
                miLector?.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return pedido;
        }

        /// <summary>
        /// Crea un nuevo pedido en la base de datos.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int CrearPedido(Pedido pedidoNuevo)
        {
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "INSERT INTO PEDIDO (idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado) VALUES (@idUsuario, @idProveedor, @fechaPedido, @estado, @observaciones, @archivado)",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idUsuario", pedidoNuevo.IdUsuario);
                miComando.Parameters.AddWithValue("@idProveedor", pedidoNuevo.IdProveedor);
                miComando.Parameters.AddWithValue("@fechaPedido", pedidoNuevo.FechaPedido);
                miComando.Parameters.AddWithValue("@estado", pedidoNuevo.Estado);
                miComando.Parameters.AddWithValue("@observaciones", pedidoNuevo.Observaciones ?? "");
                miComando.Parameters.AddWithValue("@archivado", pedidoNuevo.Archivado);

                return miComando.ExecuteNonQuery();
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }
        }

        /// <summary>
        /// Crea un nuevo pedido y devuelve el ID autogenerado.
        /// Utiliza SCOPE_IDENTITY() para obtener el ID asignado por la BBDD.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>ID del pedido creado, 0 si hubo error</returns>
        public int CrearPedidoYObtenerID(Pedido pedidoNuevo)
        {
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "INSERT INTO PEDIDO (idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado) " +
                    "VALUES (@idUsuario, @idProveedor, @fechaPedido, @estado, @observaciones, @archivado); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idUsuario", pedidoNuevo.IdUsuario);
                miComando.Parameters.AddWithValue("@idProveedor", pedidoNuevo.IdProveedor);
                miComando.Parameters.AddWithValue("@fechaPedido", pedidoNuevo.FechaPedido);
                miComando.Parameters.AddWithValue("@estado", pedidoNuevo.Estado);
                miComando.Parameters.AddWithValue("@observaciones", pedidoNuevo.Observaciones ?? "");
                miComando.Parameters.AddWithValue("@archivado", pedidoNuevo.Archivado);

                object? result = miComando.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }
        }

        /// <summary>
        /// Actualiza un pedido existente en la base de datos.
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>Número de filas afectadas</returns>
        public int ActualizarPedido(int idPedido, Pedido pedido)
        {
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "UPDATE PEDIDO SET idUsuario = @idUsuario, idProveedor = @idProveedor, fechaPedido = @fechaPedido, estado = @estado, observaciones = @observaciones WHERE idPedido = @idPedido",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idPedido", idPedido);
                miComando.Parameters.AddWithValue("@idUsuario", pedido.IdUsuario);
                miComando.Parameters.AddWithValue("@idProveedor", pedido.IdProveedor);
                miComando.Parameters.AddWithValue("@fechaPedido", pedido.FechaPedido);
                miComando.Parameters.AddWithValue("@estado", pedido.Estado);
                miComando.Parameters.AddWithValue("@observaciones", pedido.Observaciones ?? "");

                return miComando.ExecuteNonQuery();
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }
        }

        /// <summary>
        /// Cambia el estado de un pedido en la base de datos.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado (pedido/enviado/entregado)</param>
        /// <returns>Número de filas afectadas</returns>
        public int CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "UPDATE PEDIDO SET estado = @estado WHERE idPedido = @idPedido",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idPedido", idPedido);
                miComando.Parameters.AddWithValue("@estado", nuevoEstado);

                return miComando.ExecuteNonQuery();
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }
        }

        /// <summary>
        /// Archiva un pedido (soft delete). No lo elimina físicamente,
        /// sino que actualiza el campo archivado a true.
        /// </summary>
        /// <param name="idPedido">ID del pedido a archivar</param>
        /// <returns>Número de filas afectadas</returns>
        public int EliminarPedido(int idPedido)
        {
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand(
                    "UPDATE PEDIDO SET archivado = 1 WHERE idPedido = @idPedido",
                    miConexion
                );

                miComando.Parameters.AddWithValue("@idPedido", idPedido);

                return miComando.ExecuteNonQuery();
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }
        }

        #endregion
    }
}