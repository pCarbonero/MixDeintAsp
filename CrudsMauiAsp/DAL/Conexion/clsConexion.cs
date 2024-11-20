using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexion
{
    public class clsConexion
    {
        #region atributos
        private String server;
        private String dataBase;
        private String user;
        private String pass;
        #endregion

        public clsConexion()
        {
            this.server = "pcarbonerodam.database.windows.net";
            this.dataBase = "pCarboneroBD";
            this.user = "usuario";
            this.pass = "LaCampana123";
        }

        public clsConexion(string server, string dataBase, string user, string pass)
        {
            this.server = server;
            this.dataBase = dataBase;
            this.user = user;
            this.pass = pass;
        }



        /// <summary>
        /// Funcion que se encarga de realizar la conexion con un objeto SqlConnection referenciado 
        /// </summary>
        /// <param name="connection"></param>
        public void getConnection(ref SqlConnection connection)
        {
            try
            {
                connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion que se encarga de cerrar la conexion
        /// </summary>
        /// <param name="connection"></param>
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
    }
}
