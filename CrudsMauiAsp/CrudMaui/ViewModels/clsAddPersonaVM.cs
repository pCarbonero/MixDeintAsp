using BL;
using CrudMaui.ViewModels.Utilidades;
using Entidades;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    public class clsAddPersonaVM: clsPersona, INotifyPropertyChanged
    {
        #region atributos
        private clsPersona persona;
        private List<clsDepartamento> listaDepartamentos;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand addCommand;


        #endregion

        #region propiedades
        public string NuevoNombre
        {
            get { return Nombre; } 
            set { Nombre = value; NotifyPropertyChanged("NuevoNombre"); addCommand.RaiseCanExecuteChanged(); }
        }

        public string NuevoApellidos
        {
            get { return Apellidos; }
            set { Apellidos = value; NotifyPropertyChanged("NuevoApellidos"); addCommand.RaiseCanExecuteChanged(); }
        }

        public string NuevoTelefono
        {
            get { return Telefono; }
            set { Telefono = value; NotifyPropertyChanged("NuevoTelefono"); addCommand.RaiseCanExecuteChanged(); }
        }

        public string NuevoDireccion
        {
            get { return Direccion; }
            set { Direccion = value; NotifyPropertyChanged("NuevoDireccion"); addCommand.RaiseCanExecuteChanged(); }
        }

        public string NuevoFoto
        {
            get { return Foto; }
            set { Foto = value; NotifyPropertyChanged("NuevoFoto"); addCommand.RaiseCanExecuteChanged(); }
        }
        public DateTime NuevoFechaNacimiento
        {
            get { return FechaNacimiento; }
            set { FechaNacimiento = value; NotifyPropertyChanged("NuevoFechaNacimiento"); addCommand.RaiseCanExecuteChanged(); }
        }



        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set 
            { 
                departamentoSeleccionado = value; 
                NotifyPropertyChanged("DepartamentoSeleccionado");
                addCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand AddCommand
        {
            get { return addCommand; }
        }
        #endregion

        #region constructores

        public clsAddPersonaVM()
        {
            departamentoSeleccionado = new clsDepartamento();
            listaDepartamentos = clsListadosBL.listadoCompletoDepartamentosBL();
            addCommand = new DelegateCommand(addCommandExecute, addCommandCanExecute);
        }
        #endregion

        #region command
        public async void addCommandExecute()
        {
            try
            {
                    IDDepartamento = departamentoSeleccionado.Id;
                persona = new clsPersona(NuevoNombre, NuevoApellidos, NuevoTelefono, NuevoDireccion, NuevoFoto, NuevoFechaNacimiento, IDDepartamento);

                bool pudo = clsManejadoraBL.insertPersonaBL(persona);

                if (pudo)
                {
                    await Shell.Current.GoToAsync("///ListaPersonas");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se ha podido insertar", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Intentalo más tarde.", "OK");
            }
        }

        private bool addCommandCanExecute()
        {
            bool canExecute = false;

            if (!String.IsNullOrEmpty(NuevoNombre) && !String.IsNullOrEmpty(NuevoApellidos) && !String.IsNullOrEmpty(NuevoFoto) 
                && !String.IsNullOrEmpty(NuevoTelefono) && NuevoDireccion != null && departamentoSeleccionado.Id != 0) 
            { 
                canExecute = true; 
            }

            return canExecute;
        }

        #endregion

        #region notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
