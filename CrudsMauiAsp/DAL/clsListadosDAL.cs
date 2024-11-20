﻿using _07_CRUD_Personas_DAL.Conexion;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsListadosDAL
    {
        /// <summary>
        /// Static function that creates an object`s list from clsPersona from the database
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoCompletoPersonasDAL()
        {
            List<clsPersona> lista = new List<clsPersona>();
            clsPersona persona;

            clsMyConnection connection = new clsMyConnection();
            SqlConnection connect = new SqlConnection();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                connect = connection.getConnection();
                miComando.CommandText = "SELECT *  FROM personas";
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
                connection.closeConnection(ref connect);
            }

            return lista;
        }

        /// <summary>
        /// Funcion que busca una persona con un id en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>persona con id deseado</returns>
        public static clsPersona getPersonaIdDAL(int id)
        {
            clsPersona persona = new clsPersona();

            clsMyConnection connection = new clsMyConnection();
            SqlConnection connect = new SqlConnection();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                connect = connection.getConnection();
                miComando.Parameters.AddWithValue("@Id", id);
                miComando.CommandText = "SELECT *  FROM personas WHERE Id = @Id";
                miComando.Connection = connect;
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
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connection.closeConnection(ref connect);
            }

            return persona;
        }
    }
}
