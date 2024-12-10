using Biblio.DAL;
using Biblio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.BLL
{
    public class UsuarioBLL
    {
        //Objeto global
        UsuarioDTO userDTO = new UsuarioDTO();
        UsuarioDAL userDAL = new UsuarioDAL();

        //Autenticação
        public UsuarioDTO AuthenticateUserBLL(string user, string password)
        {
            return userDAL.AuthenticateUser(user, password);
        }

        //CRUD
        //Create
        public void CreateUserBLL(UsuarioDTO user)
        {
            userDAL.CreateUser(user);
        }

        //Read
        public List<UsuarioDTO> GetUserBLL()
        {
            return userDAL.GetUser();
        }

        //Update
        public void UpdateUserBLL(UsuarioDTO user)
        {
            userDAL.UpdateUser(user);
        }

        //Delete
        public void DeleteUserBLL(int idUser)
        {
            userDAL.DeleteUser(idUser);
        }

        //SearchById
        public UsuarioDTO SearchBLL(int idUser)
        {
            return userDAL.SearchByIdUser(idUser);
        }

        //SearchByName
        public UsuarioDTO SearchBLL(string nomeUser)
        {
            return userDAL.SearchByNameUser(nomeUser);
        }

        //loadDDL
        public List<TipoUsuarioDTO> GetTypeUserBLL()
        {
            return userDAL.GetTypeUser();
        }
    }
}
