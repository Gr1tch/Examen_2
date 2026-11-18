<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SistemaReparaciones.Presentacion.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Usuarios</title>
    <link rel="stylesheet" type="text/css" href="/Estilos/Estilos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <ul>
  <li><a class="active" href="Inicio.aspx">Inicio</a></li>
  <li><a href="Equipos.aspx">Equipos</a></li>
  <li><a href="Usuarios.aspx">Usuarios</a></li>
  <li><a href="AcercaDe.aspx">About</a></li>
</ul>
        </div>
            <div>
            <h1>Gestión de Usuarios</h1>
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="Todavía no hay usuarios registrados."></asp:GridView>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="false"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lblUsuarioID" runat="server" Text="Usuario ID (para editar o eliminar)"></asp:Label>
            <asp:TextBox ID="txtUsuarioID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
            <br />
            <asp:Label ID="lblcorreoelectronico" runat="server" Text="Correo Electrónico"></asp:Label>
            <asp:TextBox ID="txtcorreoelectronico" runat="server" MaxLength="150"></asp:TextBox>
            <br />
            <asp:Label ID="lbltelefono" runat="server" Text="Teléfono"></asp:Label>
            <asp:TextBox ID="txttelefono" runat="server" MaxLength="20"></asp:TextBox>
            <br />
            <asp:Label ID="lblAyudaEdicion" runat="server" Text="Para editar, escribe el Usuario ID del grid y los nuevos datos. Para eliminar, escribe el ID y pulsa Eliminar Usuario."></asp:Label>
        </div>




         <div>
     <asp:Button ID="btnAgregar" runat="server" Text="Agregar Usuario" OnClick="btnAgregar_Click" />
     <asp:Button ID="btnEditar" runat="server" Text="Editar Usuario" OnClick="btnEditar_Click" />
     <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Usuario" OnClick="btnEliminar_Click" />
 </div>



    </form>
</body>
</html>