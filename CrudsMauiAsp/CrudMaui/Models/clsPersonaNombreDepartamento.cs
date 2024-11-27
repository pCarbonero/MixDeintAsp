using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.Models
{
    public class clsPersonaNombreDepartamento: clsPersona
    {
        private string nombreDept;

        public string NombreDept { get { return nombreDept; } }

        public clsPersonaNombreDepartamento(clsPersona persona, List<clsDepartamento> listaDepartamentos)
        {
            Id = persona.Id;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            Direccion = persona.Direccion;
            Foto = persona.Foto;
            Telefono = persona.Telefono;
            FechaNacimiento = persona.FechaNacimiento;
            IDDepartamento = persona.IDDepartamento;

            string dep = listaDepartamentos.First(dept => dept.Id == persona.IDDepartamento).Nombre;

            if (dep != null)
            {
                this.nombreDept = dep;
            }
        }
    }
}
