using Biblio.DAL;
using Biblio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.BLL
{
    public class LivroBLL
    {
        //objeto global
        LivroDTO livroDTO = new LivroDTO();
        LivroDAL livroDAL = new LivroDAL();

        //CRUD
        //Create
        public void CreateLivroBLL(LivroDTO livro)
        {
            livroDAL.CreateLivro(livro);
        }

        //Read
        public List<LivroDTO> GetLivroBLL()
        {
            return livroDAL.GetLivro();
        }

        //Update
        public void UpdateLivroBLL(LivroDTO livro)
        {
            livroDAL.UpdateLivro(livro);
        }

        //Delete
        public void DeleteLivroBLL(int idLivro)
        {
            livroDAL.DeleteLivro(idLivro);
        }

        //SearchById
        public LivroDTO SearchLivroIdBLL(int idLivro)
        {
            return livroDAL.SearchLivroId(idLivro);
        }

        //SearchByName
        public LivroDTO SearchTituloLivroBLL(string nomeLivro)
        {
            return livroDAL.SearchTituloLivro(nomeLivro);
        }

        //loadDDLGenre
        public List<GeneroDTO> LoadDDLGenreBLL()
        {
            return livroDAL.LoadDDLGenero();
        }

        //FilterByGenre
        public List<LivroDTO> FilterByGenreBLL(string genero)
        {
            return livroDAL.FilterByGenero(genero);
        }
    }
}
