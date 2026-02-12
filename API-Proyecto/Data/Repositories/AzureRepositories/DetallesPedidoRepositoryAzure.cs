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
                miComando.CommandText = "SELECT IDPedido, IDProducto, Cantidad, PrecioUnitario FROM DETALLE_PEDIDO WHERE IDPedido = @IDPedido";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@IDPedido", idPedido);

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        DetallePedido detalle = new DetallePedido(
                            (int)miLector["IDPedido"],
                            (int)miLector["IDProducto"],
                            (int)miLector["Cantidad"],
                            (decimal)miLector["PrecioUnitario"]
                        );

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
                miComando.CommandText = @"SELECT d.IDPedido, d.IDProducto, d.Cantidad, d.PrecioUnitario 
                                          FROM DETALLE_PEDIDO d
                                          INNER JOIN PEDIDO p ON d.IDPedido = p.ID
                                          WHERE p.Archivado = 0";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        DetallePedido detalle = new DetallePedido(
                            (int)miLector["IDPedido"],
                            (int)miLector["IDProducto"],
                            (int)miLector["Cantidad"],
                            (decimal)miLector["PrecioUnitario"]
                        );

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
                miComando.CommandText = "SELECT IDPedido, IDProducto, Cantidad, PrecioUnitario FROM DETALLE_PEDIDO WHERE IDPedido = @IDPedido AND IDProducto = @IDProducto";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@IDPedido", idPedido);
                miComando.Parameters.AddWithValue("@IDProducto", idProducto);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    detalle = new DetallePedido(
                        (int)miLector["IDPedido"],
                        (int)miLector["IDProducto"],
                        (int)miLector["Cantidad"],
                        (decimal)miLector["PrecioUnitario"]
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
                miComando.CommandText = "INSERT INTO DETALLE_PEDIDO (IDPedido, IDProducto, Cantidad, PrecioUnitario) VALUES (@IDPedido, @IDProducto, @Cantidad, @PrecioUnitario)";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@IDPedido", detallePedidoNuevo.getIdPedido());
                miComando.Parameters.AddWithValue("@IDProducto", detallePedidoNuevo.getIdProducto());
                miComando.Parameters.AddWithValue("@Cantidad", detallePedidoNuevo.getCantidad());
                miComando.Parameters.AddWithValue("@PrecioUnitario", detallePedidoNuevo.getPrecioUnitario());

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
                miComando.CommandText = "UPDATE DETALLE_PEDIDO SET Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario WHERE IDPedido = @IDPedido AND IDProducto = @IDProducto";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@IDPedido", idPedido);
                miComando.Parameters.AddWithValue("@IDProducto", idProducto);
                miComando.Parameters.AddWithValue("@Cantidad", detallePedido.getCantidad());
                miComando.Parameters.AddWithValue("@PrecioUnitario", detallePedido.getPrecioUnitario());

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
        /// PRE: El idPedido y el idProducto no pueden ser nulos
        /// Elimina físicamente un detalle de pedido por su clave compuesta.
        /// NOTA: Este método es solo para correcciones administrativas excepcionales.
        /// Los detalles de pedidos archivados NO se eliminan, solo se filtran en consultas.
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Número de filas afectadas</returns>
        public int EliminarDetallePedido(int idPedido, int idProducto)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "DELETE FROM DETALLE_PEDIDO WHERE IDPedido = @IDPedido AND IDProducto = @IDProducto";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@IDPedido", idPedido);
                miComando.Parameters.AddWithValue("@IDProducto", idProducto);

                numeroFilasAfectadas = miComando.ExecuteNonQuery();
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

            return numeroFilasAfectadas;
        }
        #endregion
    }
}