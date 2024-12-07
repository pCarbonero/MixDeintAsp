using BL;
using Entidades;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CrudAsp.Models.ViewModels
{
    public class clsListadoPersonasConNombreDept
    {
        private List<clsPersonaNombreDepartamento> listaPersonasDept;
        private List<clsPersona> listaPersonas;
        private List<clsDepartamento> listadoDepartamentos;

        public List<clsPersonaNombreDepartamento> ListaPersonasDept
        {
            get { return listaPersonasDept; }
        }
        public clsListadoPersonasConNombreDept()
        {
            listaPersonasDept = new List<clsPersonaNombreDepartamento>();
            listadoDepartamentos = clsListadosBL.listadoCompletoDepartamentosBL();
            listaPersonas = clsListadosBL.listadoCompletoPersonasBL();
            
            foreach (clsPersona p in listaPersonas)
            {
                clsPersonaNombreDepartamento pDept = new clsPersonaNombreDepartamento(p, listadoDepartamentos);
                listaPersonasDept.Add(pDept);
            }
        }
    }
}
