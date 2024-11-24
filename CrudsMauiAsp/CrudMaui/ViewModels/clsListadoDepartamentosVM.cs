using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    public class clsListadoDepartamentosVM
    {
        public ObservableCollection<clsDepartamento> ListadoPersonas { get; }
        public clsDepartamento PersonaSeleccionada { get; set; }

        public clsListadoDepartamentosVM() { }
    }
}
