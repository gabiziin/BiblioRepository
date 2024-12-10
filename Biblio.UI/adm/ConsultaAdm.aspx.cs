using Biblio.BLL;
using Biblio.DTO;
using Biblio.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblio.UI.adm
{
    public partial class ConsultaAdm : System.Web.UI.Page
    {
        //Recursos Globais
        UsuarioBLL userBLL = new UsuarioBLL();
        UsuarioDTO userDTO = new UsuarioDTO();
        string msg = "O campo precisa ser preenchido corretamente...";
        string msg2 = "Usuário não cadastrado na base...";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGv1();
                LoadDdl1();
                txtIdUsuario.Enabled = false;

            }
        }

        //popular gv1
        public void LoadGv1()
        {
            gv1.DataSource = userBLL.GetUserBLL();
            gv1.DataBind();
        }

        //popular ddl1
        public void LoadDdl1()
        {
            ddl1.DataSource = userBLL.GetTypeUserBLL();
            ddl1.DataBind();
        }

        //Validação de página

        public bool ValidaPage()
        {
            bool valid;

            if (string.IsNullOrEmpty(txtNomeUsuario.Text))
            {
                lblNomeUsuario.Text = msg;

                lblEmailUsuario.Text = lblSenhaUsuario.Text = string.Empty;

                txtNomeUsuario.Focus();
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

        //Registrar
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {
                //preenchendo as propriedades do objeto
                userDTO.NomeUsuario = txtNomeUsuario.Text;
                userDTO.EmailUsuario = txtEmailUsuario.Text;
                userDTO.SenhaUsuario = txtSenhaUsuario.Text;

                //Seleção de tipo de usuário
                userDTO.UsuarioTp = ddl1.SelectedValue;

                //checando qual procedimento invocar
                if (string.IsNullOrEmpty(txtIdUsuario.Text))
                {
                    //cadastando registro na base
                    userBLL.CreateUserBLL(userDTO);
                    Clear.ClearControl(this);
                    txtNomeUsuario.Focus();
                    LoadGv1();
                    lblMessage.Text = $"Usuário {userDTO.NomeUsuario.ToUpper()} cadastrado com sucesso !!";
                }
                else
                {
                    //editando registro na base
                    userDTO.IdUsuario = int.Parse(txtIdUsuario.Text);
                    userBLL.UpdateUserBLL(userDTO);
                    Clear.ClearControl(this);
                    txtNomeUsuario.Focus();
                    LoadGv1();
                    lblMessage.Text = $"Usuário {userDTO.NomeUsuario.ToUpper()} editado com sucesso !!";
                }
            }
        }

        //Limpar
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtNomeUsuario.Focus();
            //Resetar a cor do gv1
            gv1.SelectedRowStyle.Reset();
        }

        //Procurar usuário
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string nomeUser = txtSearch.Text.Trim();
            userDTO = userBLL.SearchBLL(nomeUser);

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblMessage.Text = msg;
                txtSearch.Focus();
                return;
            }
            else if (userDTO == null)
            {
                lblMessage.Text = msg2;
                txtSearch.Focus();
                txtSearch.Text = string.Empty;
                return;
            }
            else
            {
                ClearLabel.ClearLabelValid(this);
                PreencheCampos();
                lblMessage.Text = txtSearch.Text = string.Empty;

            }

        }
        //Preencher dados de usuário
        private void PreencheCampos()
        {
            txtIdUsuario.Text = userDTO.IdUsuario.ToString();
            txtNomeUsuario.Text = userDTO.NomeUsuario;
            txtEmailUsuario.Text = userDTO.EmailUsuario;
            txtSenhaUsuario.Text = userDTO.SenhaUsuario;

            ddl1.SelectedValue = userDTO.UsuarioTp;
        }

        //Deletar usuário
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            userDTO.IdUsuario = int.Parse(txtIdUsuario.Text.Trim());
            userBLL.DeleteUserBLL(userDTO.IdUsuario);
            Clear.ClearControl(this);
            LoadGv1();
            txtSearch.Focus();
        }

        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearLabel.ClearLabelValid(this);
            int idUser = int.Parse(gv1.SelectedRow.Cells[1].Text);
            userDTO = userBLL.SearchBLL(idUser);
            PreencheCampos();
        }
    }
}