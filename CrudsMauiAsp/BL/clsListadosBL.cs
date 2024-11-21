using DAL;
using Entidades;

namespace BL
{
    public class clsListadosBL
    {
        /// <summary>
        /// Funcion que devuelve una lista que le envian de la capa DAL
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoCompletoPersonasBL()
        {
            List<clsPersona> lista = clsListadosDAL.listadoCompletoPersonasDAL();
            return lista;
        }

        /// <summary>
        /// Funcion que devuelve una persona que obtiene de la capa DAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsPersona getPersonaIdBL(int id)
        {
            clsPersona persona = clsListadosDAL.getPersonaIdDAL(id);
            return persona;
        }
    }
}
