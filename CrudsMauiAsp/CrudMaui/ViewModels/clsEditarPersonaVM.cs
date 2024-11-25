using BL;
using CrudMaui.Models;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    [QueryProperty(nameof(PersonaEditada), "Persona")]
    public class clsEditarPersonaVM: INotifyPropertyChanged
    {
        #region Atributos
        private clsPersona personaEditada;
        private List<clsDepartamento> listaDepartamentos;
        public clsDepartamento departamentoSeleccionado;
        #endregion

        #region Propiedades
        public clsPersona PersonaEditada 
        { 
            get { return personaEditada; } 
            set 
            { 
                personaEditada = value; 
                NotifyPropertyChanged("PersonaEditada");
            } 
        }

        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }

            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged("DepartamentoSeleccionado");
            }
        }
        #endregion

        #region Constructores
        public clsEditarPersonaVM() 
        {
            listaDepartamentos = clsListadosBL.listadoCompletoDepartamentosBL();
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
