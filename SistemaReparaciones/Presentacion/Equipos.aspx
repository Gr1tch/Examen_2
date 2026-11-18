<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="SistemaReparaciones.Presentacion.Equipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Datos Equipos</title>

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
            <h1>Gestión de Equipos</h1>
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="Todavía no hay equipos registrados."></asp:GridView>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="false"></asp:Label>
        </div>




        <div>
            <asp:Label ID="lblEquipo" runat="server" Text="Equipo ID"></asp:Label>
            <asp:TextBox ID="txtEquipoID" runat="server"></asp:TextBox>
            <br />
                 <asp:Label ID="lblTipoEquipo" runat="server" Text="Tipo de Equipo"></asp:Label>
                 <asp:TextBox ID="txtTipoEquipo" runat="server" MaxLength="100"></asp:TextBox>
                 <br />
                 <asp:Label ID="lblmodelo" runat="server" Text="Modelo"></asp:Label>
                 <asp:TextBox ID="txtmodelo" runat="server" MaxLength="100"></asp:TextBox>
            <br />
            <asp:Label ID="lblusuarioID" runat="server" Text="Usuario ID"></asp:Label>
            <asp:TextBox ID="txtusuarioID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAyudaUsuario" runat="server" Text="Para agregar o editar, usa un UsuarioID registrado en Usuarios. Para editar o eliminar, escribe el Equipo ID del grid y completa los datos correspondientes."></asp:Label>
        </div>




        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Equipo" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar Equipo" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Equipo" OnClick="btnEliminar_Click" />
        </div>



    </form>
</body>
</html>

