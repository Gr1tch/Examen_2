using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaReparaciones.CapaDatos
{
    public class DatosUsuarios
    {
        private int UsuarioID;

        public int Usuario
        {
            get { return UsuarioID; }
            set { UsuarioID = value; }
        }
        private string Nombre;

        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        private int CorreoElectronico;

        public int correoElectronico
        {
            get { return CorreoElectronico; }
            set { CorreoElectronico = value; }
        }
    }
}