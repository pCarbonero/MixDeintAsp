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
        private clsPersonaNombreDepartamento personaSeleccionada;
        private ObservableCollection<clsPersonaNombreDepartamento> listadoPersonasConNombreDept;
        private List<clsPersona> listadoPersonas;
        private DelegateCommand editarCommand;
        #endregion

        #region propiedades
        public ObservableCollection<clsPersonaNombreDepartamento> ListadoPersonasConNombreDept { get { return listadoPersonasConNombreDept; } }
        public clsPersonaNombreDepartamento PersonaSeleccionada 
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
            recargarLista();
            editarCommand = new DelegateCommand(editarCommandExecuted, editarCommandCanExecute);
        }
        #endregion

        #region Comandos
        event EventHandler CanExecuteChanged;
        /// <summary>
        /// metodo para ejecutar el comando de editarPersona
        /// </summary>
        public async void editarCommandExecuted()
        {
            //await Shell.Current.GoToAsync($"///editar?id={personaSeleccionada.Id}");
            Dictionary<string, object> diccionarioMandar = new Dictionary<string, object>();
            clsPersona personaMandar = clsListadosBL.getPersonaIdBL(personaSeleccionada.Id);

            diccionarioMandar.Add("Persona", personaMandar);

            await Shell.Current.GoToAsync("///editar", diccionarioMandar);
        }

        /// <summary>
        /// metodo para comprobar si el boton de editar puede pulsarse o no 
        /// </summary>
        /// <returns></returns>
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

        #region metodos
        public void recargarLista()
        {
            // se llena la lista (List) con la lista completa de la BL
            listadoPersonas = clsListadosBL.listadoCompletoPersonasBL();
            listadoPersonasConNombreDept = new ObservableCollection<clsPersonaNombreDepartamento>();
            // se crea una lista de departamentos
            List<clsDepartamento> listaDept = clsListadosBL.listadoCompletoDepartamentosBL();

            foreach (clsPersona persona in listadoPersonas)
            {
                clsPersonaNombreDepartamento personaNombreDept = new clsPersonaNombreDepartamento(persona, listaDept);
                listadoPersonasConNombreDept.Add(personaNombreDept);
            }
            NotifyPropertyChanged(nameof(ListadoPersonasConNombreDept));
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
