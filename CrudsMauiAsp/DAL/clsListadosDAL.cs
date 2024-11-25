using _07_CRUD_Personas_DAL.Conexion;
using DAL.Conexion;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsListadosDAL
    {
        /// <summary>
        /// Static function that creates an object`s list from clsPersona from the database
        /// </summary>
        /// <pos> Lista estará llena si hay en la base de datos si no estará null</pos>
        /// <returns></returns>
        public static List<clsPersona> listadoCompletoPersonasDAL()
        {
            List<clsPersona> lista = new List<clsPersona>();
            clsPersona persona;

            clsConexion connectionManager = new clsConexion();
            SqlConnection connect = new SqlConnection();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                connectionManager.getConnection(ref connect);
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = connect;
                miLector = miComando.ExecuteReader();


                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        persona = new clsPersona();
                        persona.Id = (int)miLector["ID"];
                        persona.Nombre = (string)miLector["Nombre"];
                        persona.Apellidos = (string)miLector["Apellidos"];
                        persona.Foto = (string)miLector["Foto"];
                        //Si sospechamos que el campo puede ser Null en la BBDD
                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }
                        persona.Direccion = (string)miLector["Direccion"];
                        persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        persona.IDDepartamento = (int)miLector["IDDepartamento"];
                        persona.Telefono = (string)miLector["Telefono"];
                        lista.Add(persona);
                    }
                }
                miLector.Close();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connectionManager.closeConnection(ref connect);
            }

            return lista;
        }

        /// <summary>
        /// Funcion que busca una persona con un id en la base de datos
        /// </summary>
        /// <pre>El id debe ser mayor que 0</pre>
        /// <pos>si encuentra a la persona en la bbdd la devuelve sino devuelve persona vacia</pos>
        /// <param name="id"></param>
        /// <returns>persona con id deseado</returns>
        public static clsPersona getPersonaIdDAL(int id)
        {
            clsPersona persona = new clsPersona();

            clsConexion connectionManager = new clsConexion();
            SqlConnection connection = new SqlConnection();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                connectionManager.getConnection(ref connection);
                miComando.Parameters.AddWithValue("@Id", id);
                miComando.CommandText = "SELECT *  FROM personas WHERE Id = @Id";
                miComando.Connection = connection;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows && miLector.Read())
                {
                    persona = new clsPersona();
                    persona.Id = (int)miLector["ID"];
                    persona.Nombre = (string)miLector["Nombre"];
                    persona.Apellidos = (string)miLector["Apellidos"];
                    persona.Foto = (string)miLector["Foto"];
                    if (miLector["FechaNacimiento"] != System.DBNull.Value)
                    {
                        persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                    }
                    persona.Direccion = (string)miLector["Direccion"];
                    persona.Telefono = (string)miLector["Telefono"];
                    persona.IDDepartamento = (int)miLector["IdDepartamento"];
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connectionManager.closeConnection(ref connection);
            }

            return persona;
        }


        /// <summary>
        /// Funcion estatica que devuelve una lista completa ede deaprtamentos
        /// </summary>
        /// <pos> Lista estará llena si hay en la base de datos si no estará null</pos>
        /// <returns></returns>
        public static List<clsDepartamento> listadoCompletoDepartamentosDAL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();
            clsDepartamento departamento;

            clsConexion connectionManager = new clsConexion();
            SqlConnection connect = new SqlConnection();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                connectionManager.getConnection(ref connect);
                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = connect;
                miLector = miComando.ExecuteReader();


                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new clsDepartamento();
                        departamento.Id = (int)miLector["ID"];
                        departamento.Nombre = (string)miLector["Nombre"];
  
                        lista.Add(departamento);
                    }
                }
                miLector.Close();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connectionManager.closeConnection(ref connect);
            }

            return lista;
        }
    }
}
