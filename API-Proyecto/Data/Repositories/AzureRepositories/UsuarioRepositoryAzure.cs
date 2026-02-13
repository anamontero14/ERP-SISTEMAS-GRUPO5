using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories.AzureRepositories
{
    /// <summary>
    /// Repositorio de Usuario con conexión a Azure SQL.
    /// Implementa la interfaz IUsuarioRepository.
    /// </summary>
    public class UsuarioRepositoryAzure : IUsuarioRepository
    {
        #region MÉTODOS CRUD
        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<Usuario> GetListaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idUsuario, nombre, email FROM USUARIO";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            IdUsuario = (int)miLector["idUsuario"],
                            Nombre = (string)miLector["nombre"],
                            Email = (string)miLector["email"]
                        };

                        listaUsuarios.Add(usuario);
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

            return listaUsuarios;
        }

        /// <summary>
        /// PRE: El idUsuario no puede ser nulo
        /// Obtiene un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a buscar</param>
        /// <returns>Usuario encontrado o null si no existe</returns>
        public Usuario? GetUsuarioPorId(int idUsuario)
        {
            Usuario? usuario = null;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idUsuario, nombre, email FROM USUARIO WHERE idUsuario = @idUsuario";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@idUsuario", idUsuario);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = (int)miLector["idUsuario"],
                        Nombre = (string)miLector["nombre"],
                        Email = (string)miLector["email"]
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

            return usuario;
        }

        /// <summary>
        /// PRE: El nombre no puede ser nulo
        /// Obtiene un usuario por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a buscar</param>
        /// <returns>Usuario encontrado o null si no existe</returns>
        public Usuario? GetUsuarioPorNombre(string nombre)
        {
            Usuario? usuario = null;
            SqlConnection? miConexion = null;
            SqlCommand? miComando = null;
            SqlDataReader? miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT idUsuario, nombre, email FROM USUARIO WHERE nombre = @nombre";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@nombre", nombre);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = (int)miLector["idUsuario"],
                        Nombre = (string)miLector["nombre"],
                        Email = (string)miLector["email"]
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

            return usuario;
        }
        #endregion
    }
}