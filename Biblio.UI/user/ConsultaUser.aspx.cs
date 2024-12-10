using Biblio.BLL;
using Biblio.DTO;
using Biblio.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblio.UI.user
{
    public partial class ConsultaUser : System.Web.UI.Page
    {
        UsuarioBLL userBLL = new UsuarioBLL();
        LivroDTO livroDTO = new LivroDTO();
        LivroBLL livroBLL = new LivroBLL();

        string msg = "O campo precisa ser preenchido corretamente !!";
        string msg2 = "Filme não cadastrado na base de dados !!";
        string msg3 = "Selecione um arquivo de imagem valido !!";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se o usuário está autenticado e o tipo de usuário foi armazenado na sessão
            if (Session["User"] == null || Session["UserType"] == null)
            {
                // Se não houver sessão ou tipo de usuário, redireciona para o login
                Response.Redirect("../Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadGv1();
            }
        }

        public void LoadGv1()
        {
            // Verifique o tipo de usuário na sessão
            string tipoUsuario = Session["UserType"].ToString(); // "1" para Admin, "2" para Comum, etc.

            if (tipoUsuario == "2")  // Tipo "2" significa usuário comum
            {
                // Recupera o nome do usuário logado
                var usuarioLogado = Session["User"].ToString();  // Nome do usuário na sessão
                var user = userBLL.GetUserBLL().FirstOrDefault(u => u.NomeUsuario == usuarioLogado);  // Recupera o usuário logado
                LoadFilmRepeater();
                //LoadDDLClassif();
                //LoadDDLGenre();

                if (user != null)
                {
                    // Exibe apenas o usuário logado no GridView
                    gv1.DataSource = new[] { user };  // Exibe o usuário logado
                    gv1.DataBind();
                }
            }
            else
            {
                // Caso contrário, exibe todos os usuários
                gv1.DataSource = userBLL.GetUserBLL();  // Exibe todos os usuários
                gv1.DataBind();
            }
        }

        public void LoadRepeater()
        {
            // Verifique o tipo de usuário na sessão
            string tipoUsuario = Session["UserType"].ToString(); // "1" para Admin, "2" para Comum, etc.

            if (tipoUsuario == "2")  // Tipo "2" significa usuário comum
            {
                // Recupera o nome do usuário logado
                var usuarioLogado = Session["User"].ToString();  // Nome do usuário na sessão
                var user = userBLL.GetUserBLL().FirstOrDefault(u => u.NomeUsuario == usuarioLogado);  // Recupera o usuário logado
                LoadFilmRepeater();  // Carrega os filmes no Repeater

                if (user != null)
                {
                    // Exibe apenas o usuário logado no Repeater
                    rptLivro.DataSource = new[] { user };  // Exibe o usuário logado
                    rptLivro.DataBind();
                }
            }
            else
            {
                // Caso contrário, exibe todos os usuários
                rptLivro.DataSource = userBLL.GetUserBLL();  // Exibe todos os usuários
                rptLivro.DataBind();
            }
        }

        // Load films into the Repeater
        public void LoadFilmRepeater()
        {
            rptLivro.DataSource = livroBLL.GetLivroBLL();  // Carrega os filmes
            rptLivro.DataBind();
        }

        //FilterByGenero
        public void FilterByGenre(string genero)
        {
            string filter = txtFiltro.Text.Trim();
            rptLivro.DataSource = livroBLL.FilterByGenreBLL(filter);
            rptLivro.DataBind();
        }



        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = txtFiltro.Text.Trim();
            var result = livroBLL.FilterByGenreBLL(filter);

            if (string.IsNullOrEmpty(txtFiltro.Text) || result.Count == 0)
            {
                Clear.ClearControl(this);
                lblFilter.Text = "Digite um gênero existente...";
                lblFilter.Text = string.Empty;
                txtFiltro.Focus();
                LoadFilmRepeater();
            }
            else
            {
                FilterByGenre(filter);
                ClearLabel.ClearLabelValid(this);
                txtFiltro.Focus();
            }
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            {
                LoadFilmRepeater();
                txtFiltro.Text = string.Empty;
                txtFiltro.Focus();
            }
        }

        protected void rptLivro_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                // Aqui você pode acessar os dados do filme selecionado
                int idLivro = int.Parse(e.CommandArgument.ToString());
                livroDTO = livroBLL.SearchLivroIdBLL(idLivro);

                // Fazer algo com o filme selecionado
            }
        }

    }
}