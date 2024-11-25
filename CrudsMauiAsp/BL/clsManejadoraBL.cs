using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsManejadoraBL
    {
        /// <summary>
        /// Funcion estatica que devuelve si se ha borrado la persona o no
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int deletePersonaBL(int id)
        {
            return clsManejadoraDAL.deletePersonaDAL(id);
        }

        /// <summary>
        /// Funcion estatica que devuelve si la persoan ha sido isnsertada o no
        /// </summary>
        /// <param name="personaInsertada"></param>
        /// <returns></returns>
        public static bool insertPersonaBL(clsPersona personaInsertada)
        {
            return clsManejadoraDAL.insertPersonaDAL(personaInsertada);
        }
        
        /// <summary>
        /// funcion estatica que devuelve si la persona ha sido actualizada correctamente o no
        /// </summary>
        /// <param name="personaActualizada"></param>
        /// <returns></returns>
        public static bool updatePersonaBL(clsPersona personaActualizada)
        {
            return clsManejadoraDAL.updatePersonaDAL(personaActualizada);
        }
    }
}
