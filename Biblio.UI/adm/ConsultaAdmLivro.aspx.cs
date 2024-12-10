using Biblio.BLL;
using Biblio.DTO;
using Biblio.UI.utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace Biblio.UI.adm
{
    public partial class ConsultaAdmLivro : System.Web.UI.Page
    {
        LivroDTO livroDTO = new LivroDTO();
        LivroBLL livroBLL = new LivroBLL();
        string msg = "O campo precisa ser preenchido corretamente...";
        string msg2 = "Livro não cadastrado na base de dados...";
        string msg3 = "Selecione um arquivo de imagem válido...";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGv2();
                LoadDDLGenre();
                txtIdLivro.Enabled = false;
            }
        }

        //LoadGv2
        public void LoadGv2()
        {
            gv2.DataSource = livroBLL.GetLivroBLL();
            gv2.DataBind();
        }

        //LoadDDLGenre
        public void LoadDDLGenre()
        {
            ddlGenero.DataSource = livroBLL.LoadDDLGenreBLL();
            ddlGenero.DataBind();
        }

        //FilterByGenero
        public void FilterByGenre(string genero)
        {
            string filter = txtFiltroGenero.Text.Trim();
            gv2.DataSource = livroBLL.FilterByGenreBLL(filter);
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
        }

        //ValidaPage
        public bool ValidaPage()
        {
            bool valid;
            DateTime dt;

            if (string.IsNullOrEmpty(txtTituloLivro.Text))
            {
                lblTituloLivro.Text = msg;
                lblEditoraLivro.Text = lblAutorLivro.Text = lblFup.Text = lblDtPubli.Text = lblSinopseLivro.Text = string.Empty;
                txtTituloLivro.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtEditoraLivro.Text))
            {
                lblEditoraLivro.Text = msg;
                lblTituloLivro.Text = lblAutorLivro.Text = lblFup.Text = lblDtPubli.Text = lblSinopseLivro.Text = string.Empty;
                txtEditoraLivro.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtAutorLivro.Text))
            {
                lblEditoraLivro.Text = msg;
                lblTituloLivro.Text = lblEditoraLivro.Text = lblFup.Text = lblDtPubli.Text = lblSinopseLivro.Text = string.Empty;
                txtAutorLivro.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtDtPubli.Text) || !DateTime.TryParse(txtDtPubli.Text, out dt))
            {
                lblDtPubli.Text = msg;
                lblTituloLivro.Text = lblEditoraLivro.Text = lblFup.Text = lblAutorLivro.Text = lblSinopseLivro.Text = string.Empty;
                txtDtPubli.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtSinopseLivro.Text))
            {
                lblSinopseLivro.Text = msg;
                lblTituloLivro.Text = lblEditoraLivro.Text = lblAutorLivro.Text = lblDtPubli.Text = lblEditoraLivro.Text = lblFup.Text = string.Empty;
                txtSinopseLivro.Focus();
                valid = false;
            }
            else
            {
                // Verificar se o arquivo foi fornecido
                if (Fup.HasFile)
                {
                    // Verificar se o arquivo é uma imagem
                    string fileExtension = Path.GetExtension(Fup.FileName).ToLower();
                    string[] validExtensions = { ".jpg", ".jpeg", ".png" };

                    if (!validExtensions.Contains(fileExtension))
                    {
                        lblFup.Text = "Por favor, selecione uma imagem válida (JPG ou PNG).";
                        Fup.Focus();
                        lblTituloLivro.Text = lblEditoraLivro.Text = lblAutorLivro.Text = lblDtPubli.Text = lblSinopseLivro.Text = string.Empty;
                        valid = false;
                    }
                    else
                    {
                        valid = true;
                    }
                }
                else
                {
                    // Arquivo não é obrigatório, então validação passa
                    valid = true;
                }
            }

            return valid;
        }


        //PreencheCampos
        public void PreencheCampos()
        {
            txtIdLivro.Text = livroDTO.IdLivro.ToString();
            txtTituloLivro.Text = livroDTO.TituloLivro;
            txtEditoraLivro.Text = livroDTO.EditoraLivro;
            txtAutorLivro.Text = livroDTO.AutorLivro;
            txtDtPubli.Text = livroDTO.DtPubli.ToString("dd/MM/yyyy");
            txtSinopseLivro.Text = livroDTO.SinopseLivro;

            ddlGenero.SelectedValue = livroDTO.GeneroId;
            img1.ImageUrl = livroDTO.UrlLivro;
        }

        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage()) // Valida a página antes de prosseguir
            {
                // Preenchendo as propriedades do objeto DTO
                livroDTO.TituloLivro = txtTituloLivro.Text.Trim();
                livroDTO.EditoraLivro = txtEditoraLivro.Text.Trim();
                livroDTO.AutorLivro = txtAutorLivro.Text.Trim();
                livroDTO.SinopseLivro = txtSinopseLivro.Text.Trim();
                livroDTO.EditoraLivro = txtEditoraLivro.Text.Trim();

                //ajustando a data
                DateTime dt = DateTime.Parse(txtDtPubli.Text);
                livroDTO.DtPubli = dt;
                livroDTO.GeneroId = ddlGenero.SelectedValue;

                // Tratamento para o upload da imagem (UrlLivro)
                if (Fup.HasFile)
                {
                    string imgFileName = Fup.FileName;
                    Fup.PostedFile.SaveAs(Server.MapPath($"~/img/{imgFileName}"));
                    livroDTO.UrlLivro = $"~/img/{imgFileName}";
                }
                else
                {
                    livroDTO.UrlLivro = img1.ImageUrl; // Caso não haja upload de imagem
                }

                // Tratamento para o upload do PDF (UrlPDF)
                if (fupPDF.HasFile)  // fupPDF é o FileUpload para o PDF
                {
                    string pdfFileName = fupPDF.FileName;
                    fupPDF.PostedFile.SaveAs(Server.MapPath($"~/pdfs/{pdfFileName}"));
                    livroDTO.UrlPDF = $"~/pdfs/{pdfFileName}";  // Salva o caminho do PDF
                }
                else
                {
                    livroDTO.UrlPDF = string.Empty;  // Caso não tenha PDF
                }

                try
                {
                    // Checando se o livro é novo ou se estamos editando um existente
                    if (string.IsNullOrEmpty(txtIdLivro.Text))
                    {
                        // Cadastrando novo livro
                        livroBLL.CreateLivroBLL(livroDTO);
                        Clear.ClearControl(this); // Limpa os campos do formulário
                        txtTituloLivro.Focus();
                        LoadGv2();  // Recarrega a grid
                        lblMessage.Text = $"Livro {livroDTO.TituloLivro.ToUpper()} cadastrado com sucesso!";
                    }
                    else
                    {
                        // Atualizando filme existente
                        livroDTO.IdLivro = int.Parse(txtIdLivro.Text); // Setando o ID para a atualização
                        livroBLL.UpdateLivroBLL(livroDTO);
                        Clear.ClearControl(this); // Limpa os campos do formulário
                        txtTituloLivro.Focus();
                        LoadGv2();  // Recarrega a grid
                        lblMessage.Text = $"Livro {livroDTO.TituloLivro.ToUpper()} atualizado com sucesso!";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Erro: {ex.Message}";
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtTituloLivro.Focus();
            //resetar a cor do gv1
            gv2.SelectedRowStyle.Reset();
            LoadGv2();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            livroDTO.TituloLivro = txtTituloLivro.Text.Trim();
            livroDTO.IdLivro = int.Parse(txtIdLivro.Text.Trim());
            livroBLL.DeleteLivroBLL(livroDTO.IdLivro);
            Clear.ClearControl(this);
            LoadGv2();
            txtSearch.Focus();
            lblMessage.Text = $"Livro {livroDTO.TituloLivro.ToUpper()} eliminado com sucesso !!";
        }

        protected void btnSearchByTitle_Click(object sender, EventArgs e)
        {
            string nomeLivro = txtSearch.Text.Trim();
            livroDTO = livroBLL.SearchTituloLivroBLL(nomeLivro);

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblMessage.Text = msg;
                txtSearch.Focus();
                return;
            }
            else if (livroDTO == null)
            {
                lblMessage.Text = msg2;
                txtSearch.Focus();
                txtSearch.Text = string.Empty;
                return;
            }
            else
            {
                PreencheCampos();
                lblMessage.Text = txtSearch.Text = string.Empty;
            }
        }

        protected void btnFiltroGenero_Click(object sender, EventArgs e)
        {
            string filter = txtFiltroGenero.Text.Trim();
            var result = livroBLL.FilterByGenreBLL(filter);

            if (string.IsNullOrEmpty(txtFiltroGenero.Text) || result.Count == 0)
            {
                Clear.ClearControl(this);
                lblFiltroGenero.Text = "Digite um gênero existente...";
                lblFiltroGenero.Text = string.Empty;
                txtFiltroGenero.Focus();
                LoadGv2();
            }
            else
            {
                FilterByGenre(filter);
                ClearLabel.ClearLabelValid(this);
                txtFiltroGenero.Focus();
            }
        }

        protected void btnClearFiltroGenero_Click(object sender, EventArgs e)
        {
            {
                LoadGv2();
                txtFiltroGenero.Text = string.Empty;
                txtFiltroGenero.Focus();
            }
        }

        protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearLabel.ClearLabelValid(this);
            int idLivro = int.Parse(gv2.SelectedRow.Cells[1].Text);
            livroDTO = livroBLL.SearchLivroIdBLL(idLivro);
            PreencheCampos();
        }
    }
}