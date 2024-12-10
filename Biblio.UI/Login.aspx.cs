using Biblio.BLL;
using Biblio.DTO;
using Biblio.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblio.UI
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioDTO user = new UsuarioDTO();
        UsuarioBLL userBLL = new UsuarioBLL();

        //load Page
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Text = "Bem-vindo a área de Login, insira suas credenciais...";
            txtNome.Focus();
        }

      

        protected void btnEntrar_Click1(object sender, EventArgs e)
        {
            // Pegar as informações digitadas pelo usuário
            string nome = txtNome.Text.Trim();
            string senha = txtSenha.Text.Trim();

            // Chama o procedimento de autenticação
            user = userBLL.AuthenticateUserBLL(nome, senha);

            if (user != null)
            {
                // Armazenando informações do usuário na sessão
                Session["User"] = user.NomeUsuario.Trim(); // Nome do usuário
                Session["UserType"] = user.UsuarioTp;      // Tipo de usuário ("1" para Admin, "2" para Comum, etc.)

                // Redirecionando com base no tipo de usuário
                switch (user.UsuarioTp)
                {
                    case "1":  // Tipo "1" significa Admin
                        Response.Redirect("adm/ConsultaAdm.aspx");
                        break;

                    case "2":  // Tipo "2" significa Usuário Comum
                        Response.Redirect("user/ConsultaUser.aspx");
                        break;

                    default:
                        lblResult.Text = "Tipo de usuário não reconhecido.";
                        break;
                }

                // lblResult.Text = $"usuário {nome} com acesso permitido !!";
            }
            else
            {
                // Caso o usuário não seja encontrado
                lblResult.Text = $"Usuário {nome.ToUpper()} não cadastrado na base de dados";
                txtNome.Focus();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtNome.Focus();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("user/CadastroUser.aspx");
        }
    }
}