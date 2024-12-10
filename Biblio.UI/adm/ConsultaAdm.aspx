<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ConsultaAdm.aspx.cs" Inherits="Biblio.UI.adm.ConsultaAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/StyleAdm.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Formulario--%>
    <ul>
        <li>
            <asp:TextBox ID="txtIdUsuario" placeholder="Id:" runat="server"></asp:TextBox>
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
            <asp:DropDownList
                ID="ddl1"
                Width="260px"
                Height="40px"
                AutoPostBack="false"
                DataValueField="IdTipoUsuario"
                DataTextField="DescricaoTipoUsuario"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Registrar" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Limpar" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" runat="server" OnClientClick="if(!confirm('Deseja realmente eliminar este registro?'))return false" Text="Deletar" OnClick="btnDelete_Click" />
        </li>
        <li></li>
        <li>
            <asp:TextBox ID="txtSearch" placeholder="Search by name:" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </li>
    </ul>

    <%--GridView--%>
    <asp:GridView ID="gv1" runat="server" OnSelectedIndexChanged="gv1_SelectedIndexChanged" AutoGenerateColumns="false">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />
            <asp:BoundField DataField="IdUsuario" HeaderText="ID" />
            <asp:BoundField DataField="NomeUsuario" HeaderText="Usuario" />
            <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
            <asp:BoundField DataField="SenhaUsuario" HeaderText="Senha" />
            <asp:BoundField DataField="UsuarioTp" HeaderText="Permissão" />
        </Columns>
        <SelectedRowStyle BackColor="White"
            ForeColor="Black"
            Font-Bold="true" />
    </asp:GridView>
</asp:Content>
