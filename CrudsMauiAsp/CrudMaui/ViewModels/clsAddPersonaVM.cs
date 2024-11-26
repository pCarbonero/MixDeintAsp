using BL;
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
    public class clsAddPersonaVM: INotifyPropertyChanged
    {
        #region
        private clsPersona persona;
        private List<clsDepartamento> listaDepartamentos;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand addCommand;
        #endregion

        #region propiedades
        public clsPersona Persona
        {
            get { return persona; }
            set { persona = value; NotifyPropertyChanged("Persona"); }
        }

        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set { departamentoSeleccionado = value; NotifyPropertyChanged("DepartamentoSeleccionado"); }
        }

        public DelegateCommand AddCommand
        {
            get { return addCommand; }
        }
        #endregion

        #region constructores

        public clsAddPersonaVM()
        {
            persona = new clsPersona();
            departamentoSeleccionado = new clsDepartamento();
            listaDepartamentos = clsListadosBL.listadoCompletoDepartamentosBL();
            addCommand = new DelegateCommand(addCommandExecute);
        }

        #endregion

        #region command

        public async void addCommandExecute()
        {
            try
            {
                persona.IDDepartamento = departamentoSeleccionado.Id;

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
                //asdiofdj
            }
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
