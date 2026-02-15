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
                miComando.CommandText = "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Pedido pedido = new Pedido
                        {
                            IdPedido = (int)miLector["idPedido"],
                            IdUsuario = (int)miLector["idUsuario"],
                            IdProveedor = (int)miLector["idProveedor"],
                            FechaPedido = (DateTime)miLector["fechaPedido"],
                            Estado = (string)miLector["estado"],
                            Observaciones = (string)miLector["observaciones"],
                            Archivado = (bool)miLector["archivado"]
                        };

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
                miComando.CommandText = "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO WHERE idUsuario = @idUsuario";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idUsuario", idUsuario);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Pedido pedido = new Pedido
                        {
                            IdPedido = (int)miLector["idPedido"],
                            IdUsuario = (int)miLector["idUsuario"],
                            IdProveedor = (int)miLector["idProveedor"],
                            FechaPedido = (DateTime)miLector["fechaPedido"],
                            Estado = (string)miLector["estado"],
                            Observaciones = (string)miLector["observaciones"],
                            Archivado = (bool)miLector["archivado"]
                        };

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
                miComando.CommandText = "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO WHERE idProveedor = @idProveedor";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idProveedor", idProveedor);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Pedido pedido = new Pedido
                        {
                            IdPedido = (int)miLector["idPedido"],
                            IdUsuario = (int)miLector["idUsuario"],
                            IdProveedor = (int)miLector["idProveedor"],
                            FechaPedido = (DateTime)miLector["fechaPedido"],
                            Estado = (string)miLector["estado"],
                            Observaciones = (string)miLector["observaciones"],
                            Archivado = (bool)miLector["archivado"]
                        };

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
                miComando.CommandText = "SELECT idPedido, idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado FROM PEDIDO WHERE idPedido = @idPedido";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idPedido", idPedido);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    pedido = new Pedido
                    {
                        IdPedido = (int)miLector["idPedido"],
                        IdUsuario = (int)miLector["idUsuario"],
                        IdProveedor = (int)miLector["idProveedor"],
                        FechaPedido = (DateTime)miLector["fechaPedido"],
                        Estado = (string)miLector["estado"],
                        Observaciones = (string)miLector["observaciones"],
                        Archivado = (bool)miLector["archivado"]
                    };
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
                miComando.CommandText = "INSERT INTO PEDIDO (idUsuario, idProveedor, fechaPedido, estado, observaciones, archivado) VALUES (@idUsuario, @idProveedor, @fechaPedido, @estado, @observaciones, @archivado)";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@idUsuario", pedidoNuevo.IdUsuario);
                miComando.Parameters.AddWithValue("@idProveedor", pedidoNuevo.IdProveedor);
                miComando.Parameters.AddWithValue("@fechaPedido", pedidoNuevo.FechaPedido);
                miComando.Parameters.AddWithValue("@estado", pedidoNuevo.Estado);
                miComando.Parameters.AddWithValue("@observaciones", pedidoNuevo.Observaciones);
                miComando.Parameters.AddWithValue("@archivado", pedidoNuevo.Archivado);

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
                miComando.CommandText = "UPDATE PEDIDO SET idUsuario = @idUsuario, idProveedor = @idProveedor, fechaPedido = @fechaPedido, estado = @estado, observaciones = @observaciones WHERE idPedido = @idPedido";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@idPedido", idPedido);
                miComando.Parameters.AddWithValue("@idUsuario", pedido.IdUsuario);
                miComando.Parameters.AddWithValue("@idProveedor", pedido.IdProveedor);
                miComando.Parameters.AddWithValue("@fechaPedido", pedido.FechaPedido);
                miComando.Parameters.AddWithValue("@estado", pedido.Estado);
                miComando.Parameters.AddWithValue("@observaciones", pedido.Observaciones);

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
                miComando.CommandText = "UPDATE PEDIDO SET estado = @estado WHERE idPedido = @idPedido";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@idPedido", idPedido);
                miComando.Parameters.AddWithValue("@estado", nuevoEstado);

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
                miComando.CommandText = "UPDATE PEDIDO SET archivado = 1 WHERE idPedido = @idPedido";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idPedido", idPedido);

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