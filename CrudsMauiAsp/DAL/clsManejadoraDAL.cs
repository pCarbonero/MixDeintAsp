using _07_CRUD_Personas_DAL.Conexion;
using DAL.Conexion;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsManejadoraDAL
    {
        /// <summary>
        /// Funcion que se encarga de borrar una persona en la base de datos segun el id pasado por parametro
        /// </summary>
        /// <pos>Si no encuentra la persona devuelve null</pos>
        /// <param name="id"></param>
        /// <returns>numero de filas afectadas en la BD</returns>
       public static int deletePersonaDAL(int id)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            clsConexion connectionManager = new clsConexion();
            SqlCommand comando = new SqlCommand();        
            comando.Parameters.AddWithValue("@id", id);

            try
            {
                connectionManager.getConnection(ref conexion);
                comando.CommandText = "DELETE FROM Personas WHERE ID=@id";
                comando.Connection = conexion;
                numeroFilasAfectadas = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                connectionManager.closeConnection(ref conexion);
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Funcion que se encarga de añadir una nueva persona a la base de datos
        /// </summary>
        /// <param name="nuevaPersona"></param>
        /// <returns>si ha sido añadida o no</returns>
        public static void insertPersonaDAL(clsPersona nuevaPersona)
        {
            SqlConnection conexion = new SqlConnection();
            clsConexion connectionManager = new clsConexion();
            SqlCommand comando = new SqlCommand();

            try
            {
                connectionManager.getConnection(ref conexion);

                comando.Parameters.AddWithValue("@nombre", nuevaPersona.Nombre);
                comando.Parameters.AddWithValue("@apellidos", nuevaPersona.Apellidos);
                comando.Parameters.AddWithValue("@telefono", nuevaPersona.Telefono);
                comando.Parameters.AddWithValue("@direccion", nuevaPersona.Direccion);
                comando.Parameters.AddWithValue("@foto", nuevaPersona.Foto);
                comando.Parameters.AddWithValue("@fechaNac", nuevaPersona.FechaNacimiento);
                comando.Parameters.AddWithValue("@idDep", nuevaPersona.IDDepartamento);

                comando.Connection = conexion;

                comando.CommandText = "INSERT INTO Personas VALUES (@nombre, @apellidos, @telefono, @direccion, @foto, @fechaNac, @idDep)";

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex) 
            { 
                throw; 
            }
            finally
            {
                connectionManager.closeConnection(ref conexion);
            }
        }

        /// <summary>
        /// Actualiza a la persona pasada por parametro
        /// </summary>
        /// <param name="nuevaPersona"></param>
        public static void updatePersonaDAL(clsPersona nuevaPersona)
        {
            SqlConnection conexion = new SqlConnection();  
            clsConexion connectionManager = new clsConexion();
            SqlCommand comando = new SqlCommand();

            try
            {
                connectionManager.getConnection(ref conexion);

                comando.Parameters.AddWithValue("@id", nuevaPersona.Id);
                comando.Parameters.AddWithValue("@nombre", nuevaPersona.Nombre);
                comando.Parameters.AddWithValue("@apellidos", nuevaPersona.Apellidos);
                comando.Parameters.AddWithValue("@telefono", nuevaPersona.Telefono);
                comando.Parameters.AddWithValue("@direccion", nuevaPersona.Direccion);
                comando.Parameters.AddWithValue("@foto", nuevaPersona.Foto);
                comando.Parameters.AddWithValue("@fechaNac", nuevaPersona.FechaNacimiento);
                comando.Parameters.AddWithValue("@idDep", nuevaPersona.IDDepartamento);

                comando.Connection = conexion;

                comando.CommandText = "UPDATE Persona SET nombre = @nombre, apellidos = @apellidos, " +
                    "telefono = @telefono, direccion = @direccion, foto = @foto, FechaNacimiento = @fechaNac, idDepartamento = @idDep " +
                    "WHERE ID = @id";

                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                connectionManager.closeConnection(ref conexion);
            }
        }
    }
}
