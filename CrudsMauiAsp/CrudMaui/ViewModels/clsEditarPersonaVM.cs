using BL;
using CrudMaui.Models;
using CrudMaui.ViewModels.Utilidades;
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
    [QueryProperty(nameof(Persona), "Persona")]
    public class clsEditarPersonaVM: INotifyPropertyChanged
    {
        #region Atributos
        private clsPersona persona;
        private List<clsDepartamento> listaDepartamentos;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand actualizarPersona;
        #endregion

        #region Propiedades
        public clsPersona Persona 
        { 
            get 
            { 
                return persona; 
            } 
            set 
            { 
                persona = value; 
                NotifyPropertyChanged("Persona");
                departamentoSeleccionado = clsListadosBL.getDepartamentoIdBL(persona.IDDepartamento);
                NotifyPropertyChanged("DepartamentoSeleccionado");
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
                actualizarPersona.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand ActualizarPersona
        {
            get { return actualizarPersona; }
        }
        #endregion

        #region Constructores
        public clsEditarPersonaVM() 
        {
            listaDepartamentos = clsListadosBL.listadoCompletoDepartamentosBL();
            actualizarPersona = new DelegateCommand(actualizarCommandExecute);
            persona = new clsPersona();
            departamentoSeleccionado = new clsDepartamento();
        }
        #endregion

        #region Comandos
        public async void actualizarCommandExecute()
        {
            persona.IDDepartamento = departamentoSeleccionado.Id;
            try
            {
                clsManejadoraBL.updatePersonaBL(persona);
                await Shell.Current.GoToAsync("///ListaPersonas");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ASJIOFH", "SAHDOSIH", "OJ");
            }
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
