using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories.AzureRepositories
{
    public class PedidoRepositoryAzure : IPedidoRepository
    {
        #region MÉTODOS CRUD

        private bool GetBool(SqlDataReader reader, string column)
        {
            return reader[column] != DBNull.Value && Convert.ToBoolean(reader[column]);
        }

        private string GetString(SqlDataReader reader, string column)
        {
            return reader[column] == DBNull.Value ? "" : reader[column].ToString()!;
        }

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
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>ID del pedido creado</returns>
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