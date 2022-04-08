using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebMensagens.MODELO;

namespace WebMensagens.DAL
{
    public class DALContatos
    {
        private System.Configuration.ConnectionStringSettings conexaoString;

        public DALContatos()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            conexaoString = rootWebConfig.ConnectionStrings.ConnectionStrings["siscontatosConnectionString"];
        }

        public void Inserir(ModeloContatos objInserir)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexao;
                cmd.CommandText = "INSERT INTO contatos(nome,foto) VALUES(@nome, @foto); SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", objInserir.NomeContato);
                cmd.Parameters.AddWithValue("foto", objInserir.Foto);
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

        public void Alterar(ModeloContatos objAlterar)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexao;
                cmd.CommandText = "UPDATE contatos SET nome = @nome, foto = @foto WHERE id = @id";
                cmd.Parameters.AddWithValue("nome", objAlterar.NomeContato);
                cmd.Parameters.AddWithValue("foto", objAlterar.Foto);
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
                cmd.CommandText = "DELETE FROM contatos WHERE id = " + codExcluir.ToString();
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM contatos", conexaoString.ConnectionString);

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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM contatos WHERE nome LIKE '%" + valor + "%'", conexaoString.ConnectionString);

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

        public ModeloContatos GetRegistro(int id)
        {
            ModeloContatos objContatos = new ModeloContatos();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao;

            try
            {
                cmd.CommandText = "SELECT * FROM contatos WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.HasRows)
                {
                    registro.Read();
                    objContatos.Id = Convert.ToInt32(registro["id"]);
                    objContatos.NomeContato = Convert.ToString(registro["nome"]);
                    objContatos.Foto = Convert.ToString(registro["foto"]);
                }
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return objContatos;
        }
    }
}