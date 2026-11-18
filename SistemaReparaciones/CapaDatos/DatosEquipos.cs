using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaReparaciones.CapaDatos
{
    public class DatosEquipos
    {
        private int EquipoID;

        public int Equipo
        {
            get { return EquipoID; }
            set { EquipoID = value; }
        }
        private string TipoEquipo;

        public string Tipo
        {
            get { return TipoEquipo; }
            set { TipoEquipo = value; }
        }

        private int Modelo;

        public int modelo
        {
            get { return Modelo; }
            set { Modelo = value; }
        }

        private int UsuarioID;

        public int Usuario
        {
            get { return UsuarioID; }
            set { UsuarioID = value; }
        }


    }
}