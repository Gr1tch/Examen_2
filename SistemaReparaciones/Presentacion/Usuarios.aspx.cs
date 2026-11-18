using System;
using System.Web.UI;

namespace SistemaReparaciones.Presentacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        private void LlenarGrid()
        {
            GridView1.DataSource = CapaLogica.LogicaUsuarios.ObtenerUsuarios();
            GridView1.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correoElectronico = txtcorreoelectronico.Text.Trim();
            string telefono = txttelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(correoElectronico) ||
                string.IsNullOrWhiteSpace(telefono))
            {
                lblMensaje.Text = "Completa nombre, correo electrónico y teléfono.";
                return;
            }

            int filasAgregadas = CapaLogica.LogicaUsuarios.AgregarUsuario(nombre, correoElectronico, telefono);
            if (filasAgregadas > 0)
            {
                txtNombre.Text = string.Empty;
                txtcorreoelectronico.Text = string.Empty;
                txttelefono.Text = string.Empty;
                LlenarGrid();
                lblMensaje.Text = "Usuario agregado correctamente.";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int usuarioID;
            if (!int.TryParse(txtUsuarioID.Text.Trim(), out usuarioID))
            {
                lblMensaje.Text = "Escribe un Usuario ID válido para editar.";
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string correoElectronico = txtcorreoelectronico.Text.Trim();
            string telefono = txttelefono.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(correoElectronico) ||
                string.IsNullOrWhiteSpace(telefono))
            {
                lblMensaje.Text = "Completa nombre, correo electrónico y teléfono para editar.";
                return;
            }

            int filasModificadas = CapaLogica.LogicaUsuarios.ModificarUsuario(
                usuarioID, nombre, correoElectronico, telefono);
            if (filasModificadas == 0)
            {
                lblMensaje.Text = "No existe un usuario con ese Usuario ID.";
                return;
            }

            txtUsuarioID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtcorreoelectronico.Text = string.Empty;
            txttelefono.Text = string.Empty;
            LlenarGrid();
            lblMensaje.Text = "Usuario modificado correctamente.";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int usuarioID;
            if (!int.TryParse(txtUsuarioID.Text.Trim(), out usuarioID))
            {
                lblMensaje.Text = "Escribe un Usuario ID válido para eliminar.";
                return;
            }

            try
            {
                int filasEliminadas = CapaLogica.LogicaUsuarios.EliminarUsuario(usuarioID);
                if (filasEliminadas == 0)
                {
                    lblMensaje.Text = "No existe un usuario con ese Usuario ID.";
                    return;
                }

                txtUsuarioID.Text = string.Empty;
                LlenarGrid();
                lblMensaje.Text = "Usuario eliminado correctamente.";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    lblMensaje.Text = "No se puede eliminar este usuario porque tiene equipos asociados. Elimina o reasigna primero esos equipos.";
                    return;
                }

                throw;
            }
        }
    }
}
