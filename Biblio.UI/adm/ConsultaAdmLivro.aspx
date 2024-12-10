<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ConsultaAdmLivro.aspx.cs" Inherits="Biblio.UI.adm.ConsultaAdmLivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/StylePDFadm.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--formulario--%>
    <ul>
        <li>
            <asp:TextBox ID="txtIdLivro" runat="server" placeholder="ID:"></asp:TextBox>
        </li>
        <li>
            <asp:TextBox ID="txtTituloLivro" runat="server" placeholder="Título:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblTituloLivro" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtEditoraLivro" runat="server" placeholder="Editora:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblEditoraLivro" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtAutorLivro" runat="server" placeholder="Autor:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblAutorLivro" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtDtPubli" placeholder="Data de Publicação:" onkeypress="$(this).mask('00/00/0000')" runat="server"></asp:TextBox>
            <asp:Label ID="lblDtPubli" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtSinopseLivro" runat="server" placeholder="Sinopse:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblSinopseLivro" runat="server" Text=""></asp:Label>
        </li>
        <%-- 
        <li>
            <asp:TextBox ID="txtUrlLivro" runat="server" placeholder="URL:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblUrlLivro" runat="server" Text=""></asp:Label>
        </li>
        --%>
        <li>
            <span>Selecione o gênero:</span>
        </li>
        <li>
            <asp:DropDownList
                ID="ddlGenero"
                Width="260px"
                Height="40px"
                CssClass="large-text"
                AutoPostBack="false"
                DataValueField="IdGenero"
                DataTextField="DescricaoGenero"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <asp:Label ID="lblImg" runat="server" Text="Insira um arquivo de imagem"></asp:Label>
            <asp:FileUpload ID="Fup" runat="server" OnChange="previewImage(this)" />
            <asp:Label ID="lblFup" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Image ID="img1" runat="server" Width="200" ClientIDMode="Static" />
        </li>
        <li>
            <br />
        </li>

        <!-- NOVO CAMPO PARA O UPLOAD DE PDF -->
        <li>
            <asp:Label ID="lblFupPDF" runat="server" Text="Insira um arquivo PDF"></asp:Label>
            <asp:FileUpload ID="fupPDF" runat="server" />
        </li>
        <li>
            <br />
        </li>
        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Registrar" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Limpar" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Deletar" OnClientClick="if(!confirm('Deseja realmente eliminar esse registro ?'))return false" OnClick="btnDelete_Click" />
        </li>
        <li>
            <br />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Procurar por título:" MaxLength="150"></asp:TextBox>

            <asp:Button ID="btnSearchByTitle" runat="server" Text="Pesquisar" OnClick="btnSearchByTitle_Click" />
            <asp:Button ID="Button1" runat="server" Text="Limpar filtro" OnClick="btnClearFiltroGenero_Click" />

            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <br />
        </li>
        <li>
            <%--Filtro por gênero--%>
            <asp:TextBox ID="txtFiltroGenero" runat="server" placeholder="Filtro por gênero:" MaxLength="150"></asp:TextBox>

            <asp:Button ID="btnFiltroGenero" runat="server" Text="Filtrar" OnClick="btnFiltroGenero_Click" />
            <asp:Button ID="btnClearFilterGenero" runat="server" Text="Limpar filtro" OnClick="btnClearFiltroGenero_Click" />

            <asp:Label ID="lblFiltroGenero" runat="server" Text=""></asp:Label>
        </li>
    </ul>

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <%--gridView--%>
    <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gv2_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Escolher" />
            <asp:BoundField DataField="IdLivro" HeaderText="ID" />
            <asp:BoundField DataField="TituloLivro" HeaderText="Título" />
            <asp:BoundField DataField="EditoraLivro" HeaderText="Editora" />
            <asp:BoundField DataField="DtPubli" HeaderText="Data de Publicação" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="SinopseLivro" HeaderText="Sinopse" />
            <asp:BoundField DataField="GeneroId" HeaderText="Gênero" />
            <asp:ImageField DataImageUrlField="UrlLivro" HeaderText="Imagem" ControlStyle-Width="100%" ControlStyle-Height="150" />
            <asp:TemplateField HeaderText="PDF">
                <ItemTemplate>
                    <%-- Verifica se o UrlPDF existe e cria um link de download --%>
                    <asp:HyperLink ID="linkDownload" runat="server"
                        Text="Download PDF"
                        NavigateUrl='<%# Eval("UrlPDF") %>'
                        Visible='<%# !string.IsNullOrEmpty(Eval("UrlPDF").ToString()) %>'
                        Target="_blank">
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <SelectedRowStyle BackColor="white"
            ForeColor="black"
            Font-Bold="true" />
    </asp:GridView>
</asp:Content>
