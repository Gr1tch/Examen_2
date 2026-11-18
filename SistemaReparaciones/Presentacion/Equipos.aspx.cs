using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReparaciones.Presentacion
{
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion_2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int equipoID;
            int usuarioID;
            if (!int.TryParse(txtEquipoID.Text.Trim(), out equipoID) ||
                !int.TryParse(txtusuarioID.Text.Trim(), out usuarioID))
            {
                lblMensaje.Text = "Escribe un número válido para Equipo ID y Usuario ID.";
                return;
            }

            string tipoEquipo = txtTipoEquipo.Text.Trim();
            string modelo = txtmodelo.Text.Trim();
            if (string.IsNullOrWhiteSpace(tipoEquipo) || string.IsNullOrWhiteSpace(modelo))
            {
                lblMensaje.Text = "Completa el tipo de equipo y el modelo.";
                return;
            }

            if (!CapaLogica.LogicaEquipos.UsuarioExiste(usuarioID))
            {
                lblMensaje.Text = "Ese UsuarioID no existe. Registra primero el usuario en Usuarios.aspx y usa el ID que aparece en su grid.";
                return;
            }

            try
            {
                int filasAgregadas = CapaLogica.LogicaEquipos.AgregarEquipos(
                    equipoID, tipoEquipo, modelo, usuarioID);

                if (filasAgregadas <= 0)
                {
                    lblMensaje.Text = "No se agregó el equipo.";
                    return;
                }

                LlenarGrid();
                txtEquipoID.Text = string.Empty;
                txtTipoEquipo.Text = string.Empty;
                txtmodelo.Text = string.Empty;
                txtusuarioID.Text = string.Empty;
                lblMensaje.Text = "Equipo agregado correctamente.";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    lblMensaje.Text = "No se pudo agregar el equipo porque el usuario ya no existe. Verifica el UsuarioID.";
                    return;
                }

                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    lblMensaje.Text = "Ese Equipo ID ya está registrado. Escribe un ID diferente.";
                    return;
                }

                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int equipoID;
            if (!int.TryParse(txtEquipoID.Text.Trim(), out equipoID))
            {
                lblMensaje.Text = "Escribe un Equipo ID válido para eliminar.";
                return;
            }

            try
            {
                int filasEliminadas = CapaLogica.LogicaEquipos.EliminarEquipos(equipoID);
                if (filasEliminadas == 0)
                {
                    lblMensaje.Text = "No existe un equipo con ese Equipo ID.";
                    return;
                }

                LlenarGrid();
                txtEquipoID.Text = string.Empty;
                lblMensaje.Text = "Equipo eliminado correctamente.";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    lblMensaje.Text = "No se puede eliminar este equipo porque tiene registros relacionados.";
                    return;
                }

                throw;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int equipoID;
            int usuarioID;
            if (!int.TryParse(txtEquipoID.Text.Trim(), out equipoID) ||
                !int.TryParse(txtusuarioID.Text.Trim(), out usuarioID))
            {
                lblMensaje.Text = "Escribe un número válido para Equipo ID y Usuario ID.";
                return;
            }

            string tipoEquipo = txtTipoEquipo.Text.Trim();
            string modelo = txtmodelo.Text.Trim();
            if (string.IsNullOrWhiteSpace(tipoEquipo) || string.IsNullOrWhiteSpace(modelo))
            {
                lblMensaje.Text = "Completa el tipo de equipo y el modelo para editar.";
                return;
            }

            if (!CapaLogica.LogicaEquipos.UsuarioExiste(usuarioID))
            {
                lblMensaje.Text = "Ese UsuarioID no existe. Usa un ID que aparezca en el grid de Usuarios.aspx.";
                return;
            }

            try
            {
                int filasModificadas = CapaLogica.LogicaEquipos.ModificarEquipos(
                    equipoID, tipoEquipo, modelo, usuarioID);

                if (filasModificadas == 0)
                {
                    lblMensaje.Text = "No existe un equipo con ese Equipo ID.";
                    return;
                }

                LlenarGrid();
                txtEquipoID.Text = string.Empty;
                txtTipoEquipo.Text = string.Empty;
                txtmodelo.Text = string.Empty;
                txtusuarioID.Text = string.Empty;
                lblMensaje.Text = "Equipo modificado correctamente.";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    lblMensaje.Text = "No se pudo modificar el equipo porque el usuario ya no existe. Verifica el UsuarioID.";
                    return;
                }

                throw;
            }
        }
    }
}