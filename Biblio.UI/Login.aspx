<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Biblio.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/StyleLogin.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="begezin">
 <ul class="Login">
     <li>
         <h1>Login</h1>
     </li>
     <li>
         <asp:TextBox ID="txtNome" runat="server" Placeholder="Email:" MaxLength="150"></asp:TextBox>
     </li>
     <li>
         <asp:TextBox ID="txtSenha" runat="server" Placeholder="Senha:" MaxLength="6"></asp:TextBox>
     </li>
     <li>
         <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click1"/>
         <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
     </li>
     <li>
         <h3>Não tem registro:</h3>
         <asp:Button ID="btnRegistrar" runat="server" Text="REGISTRE-SE" OnClick="btnRegistrar_Click" />
     </li>
     <li>
         <asp:Label ID="lblResult" runat="server"></asp:Label>
     </li>
 </ul>
     </div>
        <div class="marronzin">
            <ul class="Biblio">
                <li>
                    <h1>Biblio</h1>
                </li>
                <li>
                    <h2>A biblioteca que cabe na palma da sua mão.</h2>
                </li>
                <li>
                    <img src="img/image%20(1).png" />
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
