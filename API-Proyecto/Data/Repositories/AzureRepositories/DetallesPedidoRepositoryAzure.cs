using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories.AzureRepositories
{
    /// <summary>
    /// Repositorio de DetallePedido con conexión a Azure SQL.
    /// Implementa la interfaz IDetallesPedidoRepository.
    /// </summary>
    public class DetallesPedidoRepositoryAzure : IDetallesPedidoRepository
    {
        #region MÉTODOS CRUD
        /// <summary>
        /// Obtiene la lista de detalles de un pedido específico.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <returns>Lista de detalles del pedido</returns>
        public List<DetallePedido> GetListaDetallesPorPedido(int idPedido)
        {
            List<DetallePedido> listaDetalles = new List<DetallePedido>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idPedido, idProducto, cantidad, precioUnitario FROM DETALLE_PEDIDO WHERE idPedido = @idPedido";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idPedido", idPedido);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        DetallePedido detalle = new DetallePedido
                        {
                            IdPedido = (int)miLector["idPedido"],
                            IdProducto = (int)miLector["idProducto"],
                            Cantidad = (int)miLector["cantidad"],
                            PrecioUnitario = (decimal)miLector["precioUnitario"]
                        };

                        listaDetalles.Add(detalle);
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

            return listaDetalles;
        }

        /// <summary>
        /// Obtiene todos los detalles de pedidos activos (no archivados).
        /// </summary>
        /// <returns>Lista de detalles de pedidos activos</returns>
        public List<DetallePedido> GetListaDetallesPedidosActivos()
        {
            List<DetallePedido> listaDetalles = new List<DetallePedido>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = @"SELECT d.idPedido, d.idProducto, d.cantidad, d.precioUnitario 
                                          FROM DETALLE_PEDIDO d
                                          INNER JOIN PEDIDO p ON d.idPedido = p.idPedido
                                          WHERE p.archivado = 0";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        DetallePedido detalle = new DetallePedido
                        {
                            IdPedido = (int)miLector["idPedido"],
                            IdProducto = (int)miLector["idProducto"],
                            Cantidad = (int)miLector["cantidad"],
                            PrecioUnitario = (decimal)miLector["precioUnitario"]
                        };

                        listaDetalles.Add(detalle);
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

            return listaDetalles;
        }

        /// <summary>
        /// PRE: El idPedido y el idProducto no pueden ser nulos
        /// Obtiene un detalle de pedido por su clave compuesta.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Detalle del pedido encontrado o null si no existe</returns>
        public DetallePedido? GetDetallePedidoPorId(int idPedido, int idProducto)
        {
            DetallePedido? detalle = null;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idPedido, idProducto, cantidad, precioUnitario FROM DETALLE_PEDIDO WHERE idPedido = @idPedido AND idProducto = @idProducto";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idPedido", idPedido);
                miComando.Parameters.AddWithValue("@idProducto", idProducto);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    detalle = new DetallePedido
                    {
                        IdPedido = (int)miLector["idPedido"],
                        IdProducto = (int)miLector["idProducto"],
                        Cantidad = (int)miLector["cantidad"],
                        PrecioUnitario = (decimal)miLector["precioUnitario"]
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

            return detalle;
        }

        /// <summary>
        /// PRE: El detalle de pedido no puede ser nulo
        /// Crea un nuevo detalle de pedido.
        /// </summary>
        /// <param name="detallePedidoNuevo">Detalle de pedido a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int CrearDetallePedido(DetallePedido detallePedidoNuevo)
        {
            int filasAfectadas = 0;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "INSERT INTO DETALLE_PEDIDO (idPedido, idProducto, cantidad, precioUnitario) VALUES (@idPedido, @idProducto, @cantidad, @precioUnitario)";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@idPedido", detallePedidoNuevo.IdPedido);
                miComando.Parameters.AddWithValue("@idProducto", detallePedidoNuevo.IdProducto);
                miComando.Parameters.AddWithValue("@cantidad", detallePedidoNuevo.Cantidad);
                miComando.Parameters.AddWithValue("@precioUnitario", detallePedidoNuevo.PrecioUnitario);

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
        /// PRE: El idPedido, idProducto y detallePedido no pueden ser nulos
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="detallePedido">Datos actualizados del detalle</param>
        /// <returns>Número de filas afectadas</returns>
        public int ActualizarDetallePedido(int idPedido, int idProducto, DetallePedido detallePedido)
        {
            int filasAfectadas = 0;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "UPDATE DETALLE_PEDIDO SET cantidad = @cantidad, precioUnitario = @precioUnitario WHERE idPedido = @idPedido AND idProducto = @idProducto";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@idPedido", idPedido);
                miComando.Parameters.AddWithValue("@idProducto", idProducto);
                miComando.Parameters.AddWithValue("@cantidad", detallePedido.Cantidad);
                miComando.Parameters.AddWithValue("@precioUnitario", detallePedido.PrecioUnitario);

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