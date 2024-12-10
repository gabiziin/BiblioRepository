using Biblio.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.DAL
{
    public class LivroDAL : Conexao
    {
        string msg = "Minha vida é um fracasso...";

        //Create
        public void CreateLivro(LivroDTO livro)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Livro (TituloLivro,EditoraLivro,AutorLivro,DtPubli,SinopseLivro,UrlLivro,UrlPDF,GeneroId) VALUES (@TituloLivro,@EditoraLivro,@AutorLivro,@DtPubli,@SinopseLivro,@UrlLivro,@UrlPDF,@GeneroId)", conn);
                cmd.Parameters.AddWithValue("@TituloLivro", livro.TituloLivro);
                cmd.Parameters.AddWithValue("@EditoraLivro", livro.EditoraLivro);
                cmd.Parameters.AddWithValue("@AutorLivro", livro.AutorLivro);
                cmd.Parameters.AddWithValue("@DtPubli", livro.DtPubli);
                cmd.Parameters.AddWithValue("@SinopseLivro", livro.SinopseLivro);
                cmd.Parameters.AddWithValue("@UrlLivro", livro.UrlLivro);
                cmd.Parameters.AddWithValue("@UrlPDF", livro.UrlPDF);
                cmd.Parameters.AddWithValue("@GeneroId", livro.GeneroId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //Read
        public List<LivroDTO> GetLivro()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdLivro, TituloLivro, EditoraLivro, AutorLivro, DtPubli, SinopseLivro, UrlLivro, UrlPDF, DescricaoGenero FROM Livro INNER JOIN Genero ON GeneroId = IdGenero;", conn);
                dr = cmd.ExecuteReader();
                List<LivroDTO> listLivro = new List<LivroDTO>();//ponteiro
                while (dr.Read())
                {
                    LivroDTO livro = new LivroDTO();
                    livro.IdLivro = Convert.ToInt32(dr["IdLivro"]);
                    livro.TituloLivro = dr["TituloLivro"].ToString();
                    livro.EditoraLivro = dr["EditoraLivro"].ToString();
                    livro.AutorLivro = dr["AutorLivro"].ToString();
                    livro.DtPubli = Convert.ToDateTime(dr["DtPubli"]);
                    livro.SinopseLivro = dr["SinopseLivro"].ToString();
                    livro.UrlLivro = dr["UrlLivro"].ToString();
                    livro.UrlPDF = dr["UrlPDF"].ToString();
                    livro.GeneroId = dr["DescricaoGenero"].ToString();
                    listLivro.Add(livro);
                }
                return listLivro;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //Update
        public void UpdateLivro(LivroDTO livro)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Livro SET TituloLivro = @TituloLivro, EditoraLivro = @EditoraLivro, AutorLivro = @AutorLivro, DtPubli = @DtPubli, SinopseLivro = @SinopseLivro, UrlLivro = @UrlLivro, UrlPDF = @UrlPDF, GeneroId = @GeneroId WHERE IdLivro = @IdLivro;", conn);
                cmd.Parameters.AddWithValue("@TituloLivro", livro.TituloLivro);
                cmd.Parameters.AddWithValue("@EditoraLivro", livro.EditoraLivro);
                cmd.Parameters.AddWithValue("@AutorLivro", livro.AutorLivro);
                cmd.Parameters.AddWithValue("@DtPubli", livro.DtPubli);
                cmd.Parameters.AddWithValue("@SinopseLivro", livro.SinopseLivro);
                cmd.Parameters.AddWithValue("@UrlLivro", livro.UrlLivro);
                cmd.Parameters.AddWithValue("@UrlPDF", livro.UrlPDF);
                cmd.Parameters.AddWithValue("@GeneroId", livro.GeneroId);
                cmd.Parameters.AddWithValue("@IdLivro", livro.IdLivro);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void DeleteLivro(int idLivro)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Livro WHERE IdLivro = @IdLivro;", conn);
                cmd.Parameters.AddWithValue("@IdLivro", idLivro);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        //SearchById
        public LivroDTO SearchLivroId(int idLivro)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Livro WHERE IdLivro = @IdLivro;", conn);
                cmd.Parameters.AddWithValue("@IdLivro", idLivro);
                dr = cmd.ExecuteReader();
                LivroDTO livro = null;//ponteiro
                if (dr.Read())
                {
                    livro = new LivroDTO();
                    livro.IdLivro = Convert.ToInt32(dr["IdLivro"]);
                    livro.TituloLivro = dr["TituloLivro"].ToString();
                    livro.EditoraLivro = dr["EditoraLivro"].ToString();
                    livro.AutorLivro = dr["AutorLivro"].ToString();
                    livro.DtPubli = Convert.ToDateTime(dr["DtPubli"]);
                    livro.SinopseLivro = dr["SinopseLivro"].ToString();
                    livro.UrlLivro = dr["UrlLivro"].ToString();
                    livro.UrlPDF = dr["UrlPDF"].ToString();
                    livro.GeneroId = dr["GeneroId"].ToString();
                }
                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        //SearchByTitulo
        public LivroDTO SearchTituloLivro(string nomeLivro)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Livro WHERE TituloLivro = @TituloLivro;", conn);
                cmd.Parameters.AddWithValue("@TituloLivro", nomeLivro);
                dr = cmd.ExecuteReader();
                LivroDTO livro = null;//ponteiro
                if (dr.Read())
                {
                    livro = new LivroDTO();
                    livro.IdLivro = Convert.ToInt32(dr["IdLivro"]);
                    livro.TituloLivro = dr["TituloLivro"].ToString();
                    livro.EditoraLivro = dr["EditoraLivro"].ToString();
                    livro.AutorLivro = dr["AutorLivro"].ToString();
                    livro.DtPubli = Convert.ToDateTime(dr["DtPubli"]);
                    livro.SinopseLivro = dr["SinopseLivro"].ToString();
                    livro.UrlLivro = dr["UrlLivro"].ToString();
                    livro.UrlPDF = dr["UrlPDF"].ToString();
                    livro.GeneroId = dr["GeneroId"].ToString();
                }
                return livro;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //LoadDDLGenero
        public List<GeneroDTO> LoadDDLGenero()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> listLivro = new List<GeneroDTO>();//ponteiro
                while (dr.Read())
                {
                    GeneroDTO livroGenero = new GeneroDTO();
                    livroGenero.IdGenero = Convert.ToInt32(dr["IdGenero"]);
                    livroGenero.DescricaoGenero = dr["DescricaoGenero"].ToString();

                    listLivro.Add(livroGenero);
                }
                return listLivro;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //FilterByGenero
        public List<LivroDTO> FilterByGenero(string genero)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdLivro, TituloLivro, EditoraLivro, AutorLivro, DtPubli, SinopseLivro, UrlLivro, UrlPDF, DescricaoGenero FROM Livro INNER JOIN Genero ON GeneroId = IdGenero WHERE DescricaoGenero = @DescricaoGenero", conn);
                cmd.Parameters.AddWithValue("@DescricaoGenero", genero);
                dr = cmd.ExecuteReader();
                List<LivroDTO> listLivro = new List<LivroDTO>();//lista de livros
                while (dr.Read())
                {
                    LivroDTO livro = new LivroDTO();
                    livro.IdLivro = Convert.ToInt32(dr["IdLivro"]);
                    livro.TituloLivro = dr["TituloLivro"].ToString();
                    livro.EditoraLivro = dr["EditoraLivro"].ToString();
                    livro.AutorLivro = dr["AutorLivro"].ToString();
                    livro.DtPubli = Convert.ToDateTime(dr["DtPubli"]);
                    livro.SinopseLivro = dr["SinopseLivro"].ToString();
                    livro.UrlLivro = dr["UrlLivro"].ToString();
                    livro.UrlPDF = dr["UrlPDF"].ToString();  // Incluindo o campo UrlPDF
                    livro.GeneroId = dr["DescricaoGenero"].ToString();
                    listLivro.Add(livro);
                }
                return listLivro;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
