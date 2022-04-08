using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebMensagens.MODELO;

namespace WebMensagens.DAL
{
    public class DALMensagem
    {

        private System.Configuration.ConnectionStringSettings conexaoString;


        public DALMensagem()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            conexaoString = rootWebConfig.ConnectionStrings.ConnectionStrings["siscontatosConnectionString"];
        }
        public void Inserir(ModeloMensagem objInserir)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexao;
                cmd.CommandText = "INSERT INTO mensagens(mensagem,contato,categoria) VALUES(@mensagem,@contato,@categoria); SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("mensagem", objInserir.Texto);
                cmd.Parameters.AddWithValue("contato", objInserir.CdContato);
                cmd.Parameters.AddWithValue("categoria", objInserir.Cdcategoria);
                conexao.Open();
                objInserir.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            finally
            {
                conexao.Close();
            }

        }

        public void Alterar(ModeloMensagem objAlterar)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexao;
                cmd.CommandText = "UPDATE mensagens SET mensagem = @mensagem, contato = @contato,categoria = @categoria WHERE id = @id";
                cmd.Parameters.AddWithValue("mensagem", objAlterar.Texto);
                cmd.Parameters.AddWithValue("contato", objAlterar.CdContato);
                cmd.Parameters.AddWithValue("categoria", objAlterar.Cdcategoria);
                cmd.Parameters.AddWithValue("id", objAlterar.Id);
                conexao.Open();
                cmd.ExecuteNonQuery();

            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            finally
            {
                conexao.Close();
            }
        }

        public void Excluir(int codExcluir)


        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexao;
                cmd.CommandText = "DELETE FROM mensagens WHERE id = " + codExcluir.ToString();
                conexao.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            finally
            {
                conexao.Close();
            }

        }

        public DataTable Localizar()
        {
            DataTable tabela = new DataTable();
            String sql = "SELECT m.id, m.mensagem, m.contato, m.categoria, c.nome AS nomecontato, g.categoria AS categorianome " +
                "FROM mensagens m INNER JOIN contatos c ON m.contato = c.id " +
                "INNER JOIN categorias g ON m.categoria = g.id ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conexaoString.ConnectionString);

            try
            {
                adapter.Fill(tabela);
                return tabela;
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM mensagens WHERE mensagem LIKE '%" + valor + "%'", conexaoString.ConnectionString);

            try
            {
                adapter.Fill(tabela);
                return tabela;
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public ModeloMensagem GetRegistro(int id)
        {
            ModeloMensagem objMensagem = new ModeloMensagem();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao;

            try
            {
                cmd.CommandText = "SELECT * FROM mensagens WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.HasRows)
                {
                    registro.Read();
                    objMensagem.Id = Convert.ToInt32(registro["id"]);
                    objMensagem.Texto = Convert.ToString(registro["mensagem"]);
                    objMensagem.CdContato = Convert.ToInt32(registro["contato"]);
                    objMensagem.Cdcategoria = Convert.ToInt32(registro["categoria"]);
                }
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return objMensagem;
        }
    }
}