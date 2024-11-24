using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    public class clsEditarPersonaVM
    {
        public clsPersona PersonaEditada { get; set; }

        public clsEditarPersonaVM() { }
        public clsEditarPersonaVM(int id) 
        { 
            PersonaEditada = clsListadosBL.getPersonaIdBL(id);
        } 
    }
}
