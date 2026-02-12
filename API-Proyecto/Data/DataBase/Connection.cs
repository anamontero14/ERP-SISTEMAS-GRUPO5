using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    public class Connection
    {

        // Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
        //PROPIEDADES
        //   _server: cadena 
        //   _database: cadena, básica. Consultable/modificable.
        //   _user: cadena, básica. Consultable/modificable.
        //   _pass: cadena, básica. Consultable/modificable.

        // MÉTODOS
        //   Function getConnection() As SqlConnection
        //       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
        //   
        //   Sub closeConnection(ByRef connection As SqlConnection)
        //       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
        //

        //return "server=montero.database.windows.net;database=PersonaDB;uid=prueba;pwd=.1234abcde;trustServerCertificate = true;";

        #region ATRIBUTOS
        public String server { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Connection()
        {
            this.server = "duque.database.windows.net";
            this.dataBase = "PersonasDB";
            this.user = "prueba5";
            this.pass = "Abcd1234!";
        }
        //Con parámetros por si quisiera cambiar las conexiones
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