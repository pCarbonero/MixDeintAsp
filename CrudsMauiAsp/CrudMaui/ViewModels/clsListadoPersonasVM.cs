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
        private DelegateCommand deleteCommand;
        private DelegateCommand addCommand;
        private DelegateCommand detailsCommand;
        #endregion

        #region propiedades
        public ObservableCollection<clsPersonaNombreDepartamento> ListadoPersonasConNombreDept { get { return listadoPersonasConNombreDept; } }
        public clsPersonaNombreDepartamento PersonaSeleccionada 
        {
            get { return personaSeleccionada; }
            set 
            { 
                personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); 
                editarCommand.RaiseCanExecuteChanged();
                deleteCommand.RaiseCanExecuteChanged();
                detailsCommand.RaiseCanExecuteChanged();
            }
        }

        // propiedades de los comandos
        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
        }
        public DelegateCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public DelegateCommand AddCommand
        {
            get { return addCommand; }
        }

        public DelegateCommand DetailsCommand
        {
            get { return detailsCommand; }
        }
        #endregion

        #region constructores
        public clsListadoPersonasVM() 
        {
            recargarLista();

            editarCommand = new DelegateCommand(editarCommandExecuted, personaSelectedCommandCanExecute);
            deleteCommand = new DelegateCommand(deleteCommandExecute, personaSelectedCommandCanExecute);
            addCommand = new DelegateCommand(addCommandExecute);
            detailsCommand = new DelegateCommand(detailsCommandExecute, personaSelectedCommandCanExecute);
        }
        #endregion

        #region Comandos
        event EventHandler CanExecuteChanged;
        /// <summary>
        /// metodo para ejecutar el comando de editarPersona
        /// </summary>
        public async void editarCommandExecuted()
        {
            try
            {
                Dictionary<string, object> diccionarioMandar = new Dictionary<string, object>();
                clsPersona personaMandar = clsListadosBL.getPersonaIdBL(personaSeleccionada.Id);

                diccionarioMandar.Add("Persona", personaMandar);

                await Shell.Current.GoToAsync("///editar", diccionarioMandar);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ha ocurrido un error. Intentalo de nuevo más tarde", "OK");
            }
        }

        /// <summary>
        /// Funcion que manda una persona al vm editar persona y cambia a la vista de editar
        /// </summary>
        public async void deleteCommandExecute()
        {
            try
            {
                int lineasAfectadas = clsManejadoraBL.deletePersonaBL(personaSeleccionada.Id);

                if (lineasAfectadas > 0)
                {
                    ListadoPersonasConNombreDept.Remove(PersonaSeleccionada);
                    await Application.Current.MainPage.DisplayAlert("Borrado", "Se ha borrado correctamente", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "La persona no existe.", "OK");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ha ocurrido un error. Intentalo de nuevo más tarde", "OK");
            }
        }
        
        /// <summary>
        /// Funcion que dirige al usuario a la pantalla de añadir persona
        /// </summary>
        public async void addCommandExecute()
        {
            try
            {
                await Shell.Current.GoToAsync("///insertar");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ha ocurrido un error. Intentalo de nuevo más tarde", "OK");
            }
        }

        /// <summary>
        /// Funcion que dirige al usuario a la vista de detalles persona
        /// </summary>
        public async void detailsCommandExecute()
        {
            try
            {
                Dictionary<string, object> diccionarioMandar = new Dictionary<string, object>();

                diccionarioMandar.Add("Persona", personaSeleccionada);

                await Shell.Current.GoToAsync("///detalles", diccionarioMandar);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ha ocurrido un error. Intentalo de nuevo más tarde", "OK");
            }
        }

        /// <summary>
        /// metodo para comprobar si el boton de editar puede pulsarse o no 
        /// </summary>
        /// <returns></returns>
        public bool personaSelectedCommandCanExecute()
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
        /// <summary>
        /// Funcion que se encarga de recargar la lista por si ha habido cambios en la base de datos
        /// </summary>
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
