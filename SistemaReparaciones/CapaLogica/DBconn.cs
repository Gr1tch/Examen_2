using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaReparaciones.CapaLogica
{
    public class DBconn
    {
        public static SqlConnection ObtenerConexion()
        {
            var settings = System.Configuration.ConfigurationManager.ConnectionStrings["conexion_2"];
            if (settings == null)
            {
                throw new InvalidOperationException("No se encontró la cadena de conexión 'conexion_2' en Web.config.");
            }

            SqlConnection conexion = new SqlConnection(settings.ConnectionString);
            conexion.Open();
            return conexion;
        }
    }
}