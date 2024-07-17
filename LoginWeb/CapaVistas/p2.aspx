<%@ Page Title="" Language="C#" MasterPageFile="~/CapaVistas/Site1.Master" AutoEventWireup="true" CodeBehind="p2.aspx.cs" Inherits="LoginWeb.CapaVistas.p2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> CATALOGO DE PERMISOS</h1>
     <asp:Label ID="lmensaje" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />

    CODIGO:
    <asp:TextBox ID="TCODIGO" runat="server"></asp:TextBox>
    <br />
    DESCRIPCION
    <asp:TextBox ID="TDESCRIPCION" runat="server"></asp:TextBox>
    <br />
<br />
<br />
    <br />
    <asp:Button ID="BAGREGAR" runat="server" Text="AGREGAR" OnClick="BAGREGAR_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BBORRAR" runat="server" Text="ELIMINAR" OnClick="BBORRAR_Click" />
</asp:Content>
