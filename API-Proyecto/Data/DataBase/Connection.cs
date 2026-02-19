using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    /// <summary>
    /// Clase que gestiona la conexión con la base de datos SQL Server en Azure.
    /// Contiene los datos de conexión y métodos para abrir y cerrar conexiones.
    /// </summary>
    public class Connection
    {
        #region ATRIBUTOS
        /// <summary>
        /// Dirección del servidor de base de datos
        /// </summary>
        public String server { get; set; }

        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        public String dataBase { get; set; }

        /// <summary>
        /// Usuario de acceso a la base de datos
        /// </summary>
        public String user { get; set; }

        /// <summary>
        /// Contraseña de acceso a la base de datos
        /// </summary>
        public String pass { get; set; }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto. Inicializa la conexión con los datos del servidor Azure.
        /// </summary>
        public Connection()
        {
            this.server = "duque.database.windows.net";
            this.dataBase = "PersonasDB";
            this.user = "prueba5";
            this.pass = "Abcd1234!";
        }

        /// <summary>
        /// Constructor con parámetros para personalizar la conexión.
        /// </summary>
        /// <param name="server">Dirección del servidor</param>
        /// <param name="database">Nombre de la base de datos</param>
        /// <param name="user">Usuario de acceso</param>
        /// <param name="pass">Contraseña de acceso</param>
        public Connection(String server, String database, String user, String pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión abierta con la base de datos</returns>
        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }

        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>La conexion es cerrada</post>
        /// <param name="connection">SqlConnection pr referencia. Conexion a cerrar
        /// </param>
        public void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}