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
    public partial class CadastroUser : System.Web.UI.Page
    {
        //Recursos Globais
        UsuarioBLL userBLL = new UsuarioBLL();
        UsuarioDTO userDTO = new UsuarioDTO();
        string msg = "O campo precisa ser preenchido corretamente...";

        protected void Page_Load(object sender, EventArgs e)
        {
            txtNomeUsuario.Focus();
            lblMessage.Text = "Essa é a página de cadastro, saiba que qualquer usuário registrado por aqui é automaticamente considerado comum";
        }

        public bool ValidaPage()
        {
            bool valid;

            if (string.IsNullOrEmpty(txtNomeUsuario.Text))
            {
                lblNomeUsuario.Text = msg;
                txtNomeUsuario.Focus();
                lblEmailUsuario.Text = lblSenhaUsuario.Text = string.Empty;

                valid = false;
            }
            else if (string.IsNullOrEmpty(txtEmailUsuario.Text))
            {
                lblEmailUsuario.Text = msg;
                txtEmailUsuario.Focus();
                lblNomeUsuario.Text = lblSenhaUsuario.Text = string.Empty;

                valid = false;

            }
            else if (string.IsNullOrEmpty(txtSenhaUsuario.Text))
            {
                lblSenhaUsuario.Text = msg;
                txtSenhaUsuario.Focus();
                lblNomeUsuario.Text = lblEmailUsuario.Text = string.Empty;
                valid = false;

            }
            else
            {
                valid = true;
            }

            return valid;
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {
                // Preenchendo as propriedades do objeto
                userDTO.NomeUsuario = txtNomeUsuario.Text;
                userDTO.EmailUsuario = txtEmailUsuario.Text;
                userDTO.SenhaUsuario = txtSenhaUsuario.Text;

                // Definindo tipo do usuário como "Outros"
                userDTO.UsuarioTp = "2";

                // Garantindo que é apenas criação
                // Não permite a edição verificando e ignorando txtIdUsuario
                userBLL.CreateUserBLL(userDTO);

                // Limpando os campos e mostrando mensagem de sucesso
                Clear.ClearControl(this);
                txtNomeUsuario.Focus();
                lblResult.Text = $"Usuário {userDTO.NomeUsuario.ToUpper()} cadastrado com sucesso !!";
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtNomeUsuario.Focus();
        }

        protected void btnGoToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }
    }
}