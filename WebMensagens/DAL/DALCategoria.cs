using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMensagens.MODELO;
using System.Data;
using System.Data.SqlClient;


namespace WebMensagens.DAL
{
    public class DALCategoria
    {

        private System.Configuration.ConnectionStringSettings conexaoString;

        public DALCategoria()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            conexaoString = rootWebConfig.ConnectionStrings.ConnectionStrings["siscontatosConnectionString"];
        }

        public void Inserir(ModeloCategoria objInserir)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {

                cmd.Connection = conexao;
                cmd.CommandText = "INSERT INTO categorias(categoria) VALUES (@categoria); SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("categoria", objInserir.NomeCategoria);
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

        public void Alterar(ModeloCategoria objAlterar)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {

                cmd.Connection = conexao;
                cmd.CommandText = "UPDATE categorias SET categoria = @categoria WHERE id = @id";
                cmd.Parameters.AddWithValue("categoria", objAlterar.NomeCategoria);
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
                cmd.CommandText = "DELETE FROM categorias WHERE id = " + codExcluir.ToString();
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM categorias", conexaoString.ConnectionString);

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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM categorias WHERE categoria LIKE '%" + valor + "%'", conexaoString.ConnectionString);

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

        public ModeloCategoria GetRegistro(int id)
        {
            ModeloCategoria objcategoria = new ModeloCategoria();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao;

            try
            {
                cmd.CommandText = "SELECT * FROM categorias WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.HasRows)
                {
                    registro.Read();
                    objcategoria.Id = Convert.ToInt32(registro["id"]);
                    objcategoria.NomeCategoria = Convert.ToString(registro["categoria"]);
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return objcategoria;
        }
    }
}