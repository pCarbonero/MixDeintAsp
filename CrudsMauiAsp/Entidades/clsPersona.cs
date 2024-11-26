using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{
    public class clsPersona
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IDDepartamento { get; set; }
        #endregion

        #region constructores
        public clsPersona() { }

        public clsPersona(clsPersona p)
        {
            Id = p.Id;
            Nombre = p.Nombre;
            Apellidos = p.Apellidos;
            Telefono = p.Telefono;
            Direccion = p.Direccion;
            Foto = p.Foto;
            FechaNacimiento = p.FechaNacimiento;
            IDDepartamento = p.IDDepartamento;
        }

        public clsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            FechaNacimiento = fechaNacimiento;
            IDDepartamento = idDepartamento;
        }
        #endregion
    }
}
