<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examen.aspx.cs" Inherits="Examen.Examen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Encuestas</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Encuesta</h2>
            <p>
                <label>Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Fecha de Nacimiento:</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Correo Electrónico:</label>
                <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Carro Propio:</label>
                <asp:RadioButton ID="radioSi" runat="server" Text="Sí" GroupName="CarroPropio" />
                <asp:RadioButton ID="radioNo" runat="server" Text="No" GroupName="CarroPropio" />
            </p>
            <p>
                <asp:Button ID="btnGuardarEncuesta" runat="server" Text="Guardar Encuesta" OnClick="btnGuardarEncuesta_Click" />
                <asp:Button ID="btnLimpiarCampos" runat="server" Text="Limpiar Campos" OnClick="btnLimpiarCampos_Click" />
                <asp:Button ID="btnMostrarReporte" runat="server" Text="Mostrar Reporte" OnClick="btnMostrarReporte_Click" />
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
            </p>
        </div>
    </form>
</body>
</html>
