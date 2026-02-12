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
        #region MÉTODOS CRUD
        /// <summary>
        /// Obtiene la lista completa de pedidos.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        public List<Pedido> GetListaPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, IDUsuario, IDProveedor, FechaPedido, Estado, Observaciones, Archivado FROM PEDIDO";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Pedido pedido = new Pedido(
                            (int)miLector["ID"],
                            (int)miLector["IDUsuario"],
                            (int)miLector["IDProveedor"],
                            (DateTime)miLector["FechaPedido"],
                            (string)miLector["Estado"],
                            (string)miLector["Observaciones"],
                            (bool)miLector["Archivado"]
                        );

                        listaPedidos.Add(pedido);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miLector != null) miLector.Close();
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
            List<Pedido> listaPedidos = new List<Pedido>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, IDUsuario, IDProveedor, FechaPedido, Estado, Observaciones, Archivado FROM PEDIDO WHERE IDUsuario = @IDUsuario";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@IDUsuario", idUsuario);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Pedido pedido = new Pedido(
                            (int)miLector["ID"],
                            (int)miLector["IDUsuario"],
                            (int)miLector["IDProveedor"],
                            (DateTime)miLector["FechaPedido"],
                            (string)miLector["Estado"],
                            (string)miLector["Observaciones"],
                            (bool)miLector["Archivado"]
                        );

                        listaPedidos.Add(pedido);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miLector != null) miLector.Close();
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
            List<Pedido> listaPedidos = new List<Pedido>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, IDUsuario, IDProveedor, FechaPedido, Estado, Observaciones, Archivado FROM PEDIDO WHERE IDProveedor = @IDProveedor";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@IDProveedor", idProveedor);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Pedido pedido = new Pedido(
                            (int)miLector["ID"],
                            (int)miLector["IDUsuario"],
                            (int)miLector["IDProveedor"],
                            (DateTime)miLector["FechaPedido"],
                            (string)miLector["Estado"],
                            (string)miLector["Observaciones"],
                            (bool)miLector["Archivado"]
                        );

                        listaPedidos.Add(pedido);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miLector != null) miLector.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return listaPedidos;
        }

        /// <summary>
        /// PRE: El idPedido no puede ser nulo
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
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, IDUsuario, IDProveedor, FechaPedido, Estado, Observaciones, Archivado FROM PEDIDO WHERE ID = @ID";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@ID", idPedido);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    pedido = new Pedido(
                        (int)miLector["ID"],
                        (int)miLector["IDUsuario"],
                        (int)miLector["IDProveedor"],
                        (DateTime)miLector["FechaPedido"],
                        (string)miLector["Estado"],
                        (string)miLector["Observaciones"],
                        (bool)miLector["Archivado"]
                    );
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miLector != null) miLector.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return pedido;
        }

        /// <summary>
        /// PRE: El pedido nuevo no puede ser nulo
        /// Crea un nuevo pedido.
        /// </summary>
        /// <param name="pedidoNuevo">Pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int CrearPedido(Pedido pedidoNuevo)
        {
            int filasAfectadas = 0;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "INSERT INTO PEDIDO (IDUsuario, IDProveedor, FechaPedido, Estado, Observaciones, Archivado) VALUES (@IDUsuario, @IDProveedor, @FechaPedido, @Estado, @Observaciones, @Archivado)";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@IDUsuario", pedidoNuevo.getIdUsuario());
                miComando.Parameters.AddWithValue("@IDProveedor", pedidoNuevo.getIdProveedor());
                miComando.Parameters.AddWithValue("@FechaPedido", pedidoNuevo.getFechaPedido());
                miComando.Parameters.AddWithValue("@Estado", pedidoNuevo.getEstado());
                miComando.Parameters.AddWithValue("@Observaciones", pedidoNuevo.getObservaciones());
                miComando.Parameters.AddWithValue("@Archivado", pedidoNuevo.getArchivado());

                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return filasAfectadas;
        }

        /// <summary>
        /// PRE: El idPedido y el pedido no pueden ser nulos
        /// Actualiza un pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido a actualizar</param>
        /// <param name="pedido">Datos actualizados del pedido</param>
        /// <returns>Número de filas afectadas</returns>
        public int ActualizarPedido(int idPedido, Pedido pedido)
        {
            int filasAfectadas = 0;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "UPDATE PEDIDO SET IDUsuario = @IDUsuario, IDProveedor = @IDProveedor, FechaPedido = @FechaPedido, Estado = @Estado, Observaciones = @Observaciones WHERE ID = @ID";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@ID", idPedido);
                miComando.Parameters.AddWithValue("@IDUsuario", pedido.getIdUsuario());
                miComando.Parameters.AddWithValue("@IDProveedor", pedido.getIdProveedor());
                miComando.Parameters.AddWithValue("@FechaPedido", pedido.getFechaPedido());
                miComando.Parameters.AddWithValue("@Estado", pedido.getEstado());
                miComando.Parameters.AddWithValue("@Observaciones", pedido.getObservaciones());

                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return filasAfectadas;
        }

        /// <summary>
        /// PRE: El idPedido y el nuevoEstado no pueden ser nulos
        /// Cambia el estado de un pedido.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="nuevoEstado">Nuevo estado (pedido/enviado/entregado)</param>
        /// <returns>Número de filas afectadas</returns>
        public int CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            int filasAfectadas = 0;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "UPDATE PEDIDO SET Estado = @Estado WHERE ID = @ID";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@ID", idPedido);
                miComando.Parameters.AddWithValue("@Estado", nuevoEstado);

                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return filasAfectadas;
        }

        /// <summary>
        /// PRE: El idPedido no puede ser nulo
        /// Elimina un pedido por su identificador (actualiza el campo Archivado a true).
        /// NOTA: Los pedidos NO se eliminan físicamente de la base de datos.
        /// </summary>
        /// <param name="idPedido">ID del pedido a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        public int EliminarPedido(int idPedido)
        {
            int filasAfectadas = 0;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "UPDATE PEDIDO SET Archivado = 1 WHERE ID = @ID";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@ID", idPedido);

                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return filasAfectadas;
        }
        #endregion
    }
}