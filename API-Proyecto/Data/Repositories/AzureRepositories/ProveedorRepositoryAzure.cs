using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories.AzureRepositories
{
    /// <summary>
    /// Repositorio de Proveedor con conexión a Azure SQL.
    /// Implementa la interfaz IProveedorRepository.
    /// </summary>
    public class ProveedorRepositoryAzure : IProveedorRepository
    {
        #region MÉTODOS CRUD
        /// <summary>
        /// Obtiene la lista completa de proveedores.
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        public List<Proveedor> GetListaProveedores()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idProveedor, cifProveedor, nombreProveedor, telefonoProveedor, emailProveedor, direccionProveedor FROM PROVEEDOR";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Proveedor proveedor = new Proveedor
                        {
                            IdProveedor = (int)miLector["idProveedor"],
                            CifProveedor = (string)miLector["cifProveedor"],
                            NombreProveedor = (string)miLector["nombreProveedor"],
                            TelefonoProveedor = (string)miLector["telefonoProveedor"],
                            EmailProveedor = (string)miLector["emailProveedor"],
                            DireccionProveedor = (string)miLector["direccionProveedor"]
                        };

                        listaProveedores.Add(proveedor);
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

            return listaProveedores;
        }

        /// <summary>
        /// PRE: El idProveedor no puede ser nulo
        /// Obtiene un proveedor por su identificador.
        /// </summary>
        /// <param name="idProveedor">ID del proveedor a buscar</param>
        /// <returns>Proveedor encontrado o null si no existe</returns>
        public Proveedor? GetProveedorPorId(int idProveedor)
        {
            Proveedor? proveedor = null;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idProveedor, cifProveedor, nombreProveedor, telefonoProveedor, emailProveedor, direccionProveedor FROM PROVEEDOR WHERE idProveedor = @idProveedor";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idProveedor", idProveedor);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    proveedor = new Proveedor
                    {
                        IdProveedor = (int)miLector["idProveedor"],
                        CifProveedor = (string)miLector["cifProveedor"],
                        NombreProveedor = (string)miLector["nombreProveedor"],
                        TelefonoProveedor = (string)miLector["telefonoProveedor"],
                        EmailProveedor = (string)miLector["emailProveedor"],
                        DireccionProveedor = (string)miLector["direccionProveedor"]
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

            return proveedor;
        }
        #endregion
    }
}