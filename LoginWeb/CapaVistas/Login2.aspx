<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="LoginWeb.CapaVistas.Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/Loginc2Css.css" rel="stylesheet" />
    <title></title>
</head>
<body>
   
            <form id="form1" runat="server">
               
              <div class='bold-line'></div>
<div class='container'>
  <div class='window'>
    <div class='overlay'></div>
    <div class='content'>
      <div class='welcome'>Hello There!</div>
      <div class='subtitle'>We're almost done. Before using our services you need to create an account.</div>
      <div class='input-fields'>

          <asp:TextBox ID="tusuario" placeholder='Email'  runat="server"  class='input-line full-width'></asp:TextBox>
          <asp:TextBox ID="tclave" placeholder='Password' runat="server"  class='input-line full-width'></asp:TextBox>
      </div>

      <div>
        
          <asp:Button ID="bingresar" runat="server" Text="Ingresar" class='ghost-round full-width' OnClick="bingresar_Click" />
      </div>
    </div>
  </div>
</div>
            </form>
   
</body>

</html>
