using System.Data;
using System.Data.SqlClient;

namespace SistemaReparaciones.CapaLogica
{
    public class LogicaUsuarios
    {
        public static DataTable ObtenerUsuarios()
        {
            using (SqlConnection conn = DBconn.ObtenerConexion())
            using (SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT UsuarioID, Nombre, CorreoElectronico, Telefono FROM dbo.Usuarios ORDER BY UsuarioID", conn))
            {
                DataTable usuarios = new DataTable();
                adapter.Fill(usuarios);
                return usuarios;
            }
        }

        public static int AgregarUsuario(string nombre, string correoElectronico, string telefono)
        {
            using (SqlConnection conn = DBconn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO dbo.Usuarios (Nombre, CorreoElectronico, Telefono) VALUES (@Nombre, @CorreoElectronico, @Telefono)", conn))
            {
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;
                cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 150).Value = correoElectronico;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = telefono;

                return cmd.ExecuteNonQuery();
            }
        }

        public static int ModificarUsuario(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            using (SqlConnection conn = DBconn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE dbo.Usuarios SET Nombre = @Nombre, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono WHERE UsuarioID = @UsuarioID", conn))
            {
                cmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuarioID;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;
                cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 150).Value = correoElectronico;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = telefono;
                return cmd.ExecuteNonQuery();
            }
        }

        public static int EliminarUsuario(int usuarioID)
        {
            using (SqlConnection conn = DBconn.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.Usuarios WHERE UsuarioID = @UsuarioID", conn))
            {
                cmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = usuarioID;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
