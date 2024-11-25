using BL;
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
        private int idPersona;
        private clsPersona personaEditada;

        public clsPersona PersonaEditada 
        { 
            get { return personaEditada; } 
            set 
            { 
                personaEditada = value; 
                NotifyPropertyChanged("PersonaEditada");
            } 
        }


        public clsEditarPersonaVM() 
        { 
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));

        }
    }
}
