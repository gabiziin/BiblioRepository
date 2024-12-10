<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroUser.aspx.cs" Inherits="Biblio.UI.user.CadastroUser" %>

<!DOCTYPE html>
<link href="../css/StyleCadastro.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro</title>
</head>
<body>

    <form id="form1" runat="server">
        <ul class="Login">
            <li>
                <h1>Cadastro de Usuário</h1>
            </li>
            <li>
                <asp:TextBox ID="txtNomeUsuario" MaxLength="150" placeholder="Nome:" runat="server"></asp:TextBox>
                <asp:Label ID="lblNomeUsuario" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:TextBox ID="txtEmailUsuario" MaxLength="150" placeholder="Email:" runat="server"></asp:TextBox>
                <asp:Label ID="lblEmailUsuario" runat="server" Text=""></asp:Label>

            </li>
            <li>
                <asp:TextBox ID="txtSenhaUsuario" MaxLength="6" placeholder="Senha:" runat="server"></asp:TextBox>
                <asp:Label ID="lblSenhaUsuario" runat="server" Text=""></asp:Label>

            </li>
            <li>
                <asp:Button ID="btnCadastro" runat="server" Text="Cadastrar" OnClick="btnCadastro_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                <asp:Button ID="btnGoToLogin" runat="server" Text="Voltar" OnClick="btnGoToLogin_Click" />
            </li>
            <li>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </li>
        </ul>
    </form>

</body>
</html>
