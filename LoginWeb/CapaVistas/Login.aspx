<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginWeb.CapaVistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/logincss.css" rel="stylesheet" />
</head>
<body>
    <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div>
    <form id="form1" runat="server">
        <h3>Login Here</h3>

        <label for="username">Username</label>
        
        <asp:TextBox ID="tusuario" runat="server"></asp:TextBox>

        <label for="password">Password</label>
        
        <asp:TextBox ID="tclave" type="Password" runat="server"></asp:TextBox>

        <asp:Button ID="bingresar" class="button" runat="server" Text="Ingresar" OnClick="bingresar_Click" />
        <asp:Label ID="lmensaje" runat="server" ForeColor="Red"></asp:Label>
        <div class="social">
          <div class="go"><i class="fab fa-google"></i>  Google</div>
          <div class="fb"><i class="fab fa-facebook"></i>  Facebook</div>
        </div>
       
      </form>
</body>
</html>
