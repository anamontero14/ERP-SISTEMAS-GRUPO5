using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories.AzureRepositories
{
    /// <summary>
    /// Repositorio de Producto con conexión a Azure SQL.
    /// Implementa la interfaz IProductoRepository.
    /// </summary>
    public class ProductoRepositoryAzure : IProductoRepository
    {
        #region MÉTODOS CRUD
        /// <summary>
        /// Obtiene la lista completa de productos.
        /// </summary>
        /// <returns>Lista de productos</returns>
        public List<Producto> GetListaProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idProducto, nombreProducto, descripcionProducto, precioProducto, stockProducto, procedenciaProducto FROM PRODUCTO";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Producto producto = new Producto
                        {
                            IdProducto = (int)miLector["idProducto"],
                            NombreProducto = (string)miLector["nombreProducto"],
                            DescripcionProducto = (string)miLector["descripcionProducto"],
                            PrecioProducto = (decimal)miLector["precioProducto"],
                            StockProducto = (int)miLector["stockProducto"],
                            ProcedenciaProducto = (string)miLector["procedenciaProducto"]
                        };

                        listaProductos.Add(producto);
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

            return listaProductos;
        }

        /// <summary>
        /// PRE: El idProducto no puede ser nulo
        /// Obtiene un producto por su identificador.
        /// </summary>
        /// <param name="idProducto">ID del producto a buscar</param>
        /// <returns>Producto encontrado o null si no existe</returns>
        public Producto? GetProductoPorId(int idProducto)
        {
            Producto? producto = null;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idProducto, nombreProducto, descripcionProducto, precioProducto, stockProducto, procedenciaProducto FROM PRODUCTO WHERE idProducto = @idProducto";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idProducto", idProducto);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    producto = new Producto
                    {
                        IdProducto = (int)miLector["idProducto"],
                        NombreProducto = (string)miLector["nombreProducto"],
                        DescripcionProducto = (string)miLector["descripcionProducto"],
                        PrecioProducto = (decimal)miLector["precioProducto"],
                        StockProducto = (int)miLector["stockProducto"],
                        ProcedenciaProducto = (string)miLector["procedenciaProducto"]
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

            return producto;
        }
        #endregion
    }
}