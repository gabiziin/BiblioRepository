using Biblio.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.DAL
{
    public class UsuarioDAL : Conexao
    {
        string msg = "Minha vida é um fracasso...";

        // Autenticar usuário
        public UsuarioDTO AuthenticateUser(string nomeUser, string senhaUser)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @nomeUsuario AND SenhaUsuario = @senhaUsuario;", conn);
                cmd.Parameters.AddWithValue("@nomeUsuario", nomeUser);
                cmd.Parameters.AddWithValue("@senhaUsuario", senhaUser);
                dr = cmd.ExecuteReader();

                UsuarioDTO user = null; // Ponteiro para o objeto de usuário
                if (dr.Read())
                {
                    user = new UsuarioDTO();
                    user.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    user.NomeUsuario = dr["NomeUsuario"].ToString();
                    user.EmailUsuario = dr["EmailUsuario"].ToString();
                    user.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    user.UsuarioTp = dr["UsuarioTp"].ToString(); // Recupera o tipo de usuário
                }
                return user;

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

        //CRUD
        //Create
        public void CreateUser(UsuarioDTO user)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Usuario (NomeUsuario,EmailUsuario,SenhaUsuario,UsuarioTp) VALUES (@NomeUsuario,@EmailUsuario,@SenhaUsuario,@UsuarioTp)", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", user.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", user.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", user.SenhaUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTp", user.UsuarioTp);
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
        public List<UsuarioDTO> GetUser()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdUsuario,NomeUsuario, EmailUsuario,SenhaUsuario,DescricaoTipoUsuario FROM Usuario INNER JOIN TipoUsuario ON UsuarioTp = IdTipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<UsuarioDTO> listUser = new List<UsuarioDTO>();//ponteiro
                while (dr.Read())
                {
                    UsuarioDTO user = new UsuarioDTO();
                    user.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    user.NomeUsuario = dr["NomeUsuario"].ToString();
                    user.EmailUsuario = dr["EmailUsuario"].ToString();
                    user.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    user.UsuarioTp = dr["DescricaoTipoUsuario"].ToString();
                    listUser.Add(user);
                }
                return listUser;

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
        public void UpdateUser(UsuarioDTO user)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Usuario SET NomeUsuario = @NomeUsuario,EmailUsuario = @EmailUsuario,SenhaUsuario = @SenhaUsuario,UsuarioTp = @UsuarioTp WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", user.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", user.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", user.SenhaUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTp", user.UsuarioTp);
                //passando o id para condicao WHERE do comando sql
                cmd.Parameters.AddWithValue("@IdUsuario", user.IdUsuario);
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
        public void DeleteUser(int idUser)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUser);
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
        public UsuarioDTO SearchByIdUser(int idUser)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUser);
                dr = cmd.ExecuteReader();
                UsuarioDTO user = null;//ponteiro
                if (dr.Read())
                {
                    user = new UsuarioDTO();
                    user.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    user.NomeUsuario = dr["NomeUsuario"].ToString();
                    user.EmailUsuario = dr["EmailUsuario"].ToString();
                    user.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    user.UsuarioTp = dr["UsuarioTp"].ToString();
                }
                return user;

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

        public UsuarioDTO SearchByNameUser(string nomeUsuario)
        {
            try
            {
                Conectar();
                // Cria o comando SQL para buscar pelo NomeUsuario
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", nomeUsuario);

                // Executa o comando e obtém o resultado
                dr = cmd.ExecuteReader();
                UsuarioDTO user = null; // Ponteiro para o objeto UsuarioDTO

                // Verifica se encontrou algum registro
                if (dr.Read())
                {
                    user = new UsuarioDTO();
                    user.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    user.NomeUsuario = dr["NomeUsuario"].ToString();
                    user.EmailUsuario = dr["EmailUsuario"].ToString();
                    user.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    user.UsuarioTp = dr["UsuarioTp"].ToString();
                }

                // Retorna o usuário encontrado ou null se não encontrar
                return user;
            }
            catch (Exception ex)
            {
                // Lança uma exceção com uma mensagem personalizada
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                // Garante que a conexão será fechada
                Desconectar();
            }
        }

        //LoadDDList
        public List<TipoUsuarioDTO> GetTypeUser()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<TipoUsuarioDTO> listUser = new List<TipoUsuarioDTO>();//ponteiro
                while (dr.Read())
                {
                    TipoUsuarioDTO userTp = new TipoUsuarioDTO();
                    userTp.IdTipoUsuario = Convert.ToInt32(dr["IdTipoUsuario"]);
                    userTp.DescricaoTipoUsuario = dr["DescricaoTipoUsuario"].ToString();

                    listUser.Add(userTp);
                }
                return listUser;

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
