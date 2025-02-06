namespace CrudAsp.Models
{
    public class clsMensajeUsuario
    {
        #region Propiedades
        public string NombreUsuario { get; set; }
        public string MensajeUsuario { get; set; }
        public string Grupo { get; set; }
        #endregion

        #region constructores
        public clsMensajeUsuario() { }
        public clsMensajeUsuario(string nombreUsuario, string mensajeUsuario)
        {
            NombreUsuario = nombreUsuario;
            MensajeUsuario = mensajeUsuario;
        }

        public clsMensajeUsuario(string nombreUsuario, string mensajeUsuario, string grupo)
        {
            NombreUsuario = nombreUsuario;
            MensajeUsuario = mensajeUsuario;
            Grupo = grupo;
        }

        #endregion
    }
}
