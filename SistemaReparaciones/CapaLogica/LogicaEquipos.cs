using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaReparaciones.CapaLogica
{
    public class LogicaEquipos
    {
        public static bool UsuarioExiste(int usuarioID)
        {
            using (SqlConnection conn = CapaLogica.DBconn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT CASE WHEN EXISTS (SELECT 1 FROM dbo.Usuarios WHERE UsuarioID = @UsuarioID) THEN 1 ELSE 0 END", conn))
            {
                cmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuarioID;
                return (int)cmd.ExecuteScalar() == 1;
            }
        }

        public static int AgregarEquipos(int EquipoID, string TipoEquipo, string modelo, int usuarioID)
        {
            using (SqlConnection conn = CapaLogica.DBconn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                @"SET IDENTITY_INSERT dbo.Equipos ON;
                  BEGIN TRY
                      INSERT INTO dbo.Equipos (EquipoID, TipoEquipo, Modelo, UsuarioID)
                      VALUES (@EquipoID, @TipoEquipo, @Modelo, @UsuarioID);
                      SET IDENTITY_INSERT dbo.Equipos OFF;
                  END TRY
                  BEGIN CATCH
                      SET IDENTITY_INSERT dbo.Equipos OFF;
                      THROW;
                  END CATCH;", conn))
            {
                cmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = EquipoID;
                cmd.Parameters.Add("@TipoEquipo", SqlDbType.VarChar, 100).Value = TipoEquipo;
                cmd.Parameters.Add("@Modelo", SqlDbType.VarChar, 100).Value = modelo;
                cmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuarioID;

                return cmd.ExecuteNonQuery();
            }
        }

        public static int ModificarEquipos(int equipoID, string tipoEquipo, string modelo, int usuarioID)
        {
            using (SqlConnection conn = CapaLogica.DBconn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE dbo.Equipos SET TipoEquipo = @TipoEquipo, Modelo = @Modelo, UsuarioID = @UsuarioID WHERE EquipoID = @EquipoID", conn))
            {
                cmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = equipoID;
                cmd.Parameters.Add("@TipoEquipo", SqlDbType.VarChar, 100).Value = tipoEquipo;
                cmd.Parameters.Add("@Modelo", SqlDbType.VarChar, 100).Value = modelo;
                cmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuarioID;
                return cmd.ExecuteNonQuery();
            }
        }
        public static int EliminarEquipos(int EquipoID)
        {
            using (SqlConnection conn = CapaLogica.DBconn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.Equipos WHERE EquipoID = @EquipoID", conn))
            {
                cmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = EquipoID;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}