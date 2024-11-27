using CrudMaui.Models;
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
    public class clsDetallesPersonaVM: INotifyPropertyChanged
    {
        private clsPersonaNombreDepartamento persona;

        public clsPersonaNombreDepartamento Persona
        {
            get { return persona; }
            set { persona = value; NotifyPropertyChanged("Persona"); }
        }
        public clsDetallesPersonaVM() { }


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
