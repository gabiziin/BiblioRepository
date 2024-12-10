using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.DAL
{
    public class Conexao
    {
        //campo de apoio
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        //procedimentos
        public void Conectar()
        {
            try
            {
                //Descomentar essa linha quando estiver trabalhando no SENAC \/
                conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = BiblioDB;Integrated Security = true");

                //Descomentar essa linha quando estiver trabalhando em casa \/
                //conn = new SqlConnection(@"Data Source = localhost; Initial Catalog = BiblioDB;Integrated Security = true");

                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
