using CrudMaui.ViewModels.Utilidades;
using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrudMaui.Models;

namespace CrudMaui.ViewModels
{
    public class clsListadoPersonasVM: INotifyPropertyChanged
    {
        #region atributos
        private clsPersona personaSeleccionada;
        private ObservableCollection<clsPersonaNombreDepartamento> listadoPersonasConNombreDept;
        private List<clsPersona> listadoPersonas;
        private DelegateCommand editarCommand;
        #endregion

        #region propiedades
        public ObservableCollection<clsPersonaNombreDepartamento> ListadoPersonasConNombreDept { get { return listadoPersonasConNombreDept; } }
        public clsPersona PersonaSeleccionada 
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); editarCommand.RaiseCanExecuteChanged(); }
        }
        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
        }
        #endregion

        #region constructores
        public clsListadoPersonasVM() 
        { 
            // se llena la lista (List) con la lista completa de la BL
            listadoPersonas = clsListadosBL.listadoCompletoPersonasBL();
            listadoPersonasConNombreDept = new ObservableCollection<clsPersonaNombreDepartamento>();

            // se crea una lista de departamentos
            List<clsDepartamento> listaDept = clsListadosBL.listadoCompletoDepartamentosBL();

            foreach(clsPersona persona in listadoPersonas)
            {
                clsPersonaNombreDepartamento personaNombreDept = new clsPersonaNombreDepartamento(persona, listaDept);
                listadoPersonasConNombreDept.Add(personaNombreDept);
            }

            editarCommand = new DelegateCommand(editarCommandExecuted, editarCommandCanExecute);
        }
        #endregion

        #region Comandos
        event EventHandler CanExecuteChanged;
        public async void editarCommandExecuted()
        {
            //await Shell.Current.GoToAsync($"///editar?id={personaSeleccionada.Id}");
            Dictionary<string, object> diccionarioMandar = new Dictionary<string, object>();

            diccionarioMandar.Add("Persona", PersonaSeleccionada);

            await Shell.Current.GoToAsync("///editar", diccionarioMandar);
        }

        public bool editarCommandCanExecute()
        {
            bool canExecute = false;

            if (personaSeleccionada != null)
            {
                canExecute = true;
            }

            return canExecute;
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
