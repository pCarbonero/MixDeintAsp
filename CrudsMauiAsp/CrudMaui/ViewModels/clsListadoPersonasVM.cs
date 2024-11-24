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
    public class clsListadoPersonasVM
    {
        public ObservableCollection<clsPersona> ListadoPersonas { get; }
        public clsPersona PersonaSeleccionada { get; set; }

        public clsListadoPersonasVM() { ListadoPersonas = new ObservableCollection<clsPersona>(clsListadosBL.listadoCompletoPersonasBL()); }
    }
}
