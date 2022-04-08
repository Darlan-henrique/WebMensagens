using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebMensagens.MODELO;

namespace WebMensagens.DAL
{
    public class DALUsuario
    {
        private System.Configuration.ConnectionStringSettings conexaoString;


        public DALUsuario()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            conexaoString = rootWebConfig.ConnectionStrings.ConnectionStrings["siscontatosConnectionString"];
        }

        public void Inserir(ModeloUsuario objInserir)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexao;
                cmd.CommandText = "INSERT INTO usuarios(nome,email,senha) VALUES(@nome,@email,@senha); SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", objInserir.NomeUsuario);
                cmd.Parameters.AddWithValue("email", objInserir.Email);
                cmd.Parameters.AddWithValue("senha", objInserir.Senha);
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

        public void Alterar(ModeloUsuario objAlterar)
        {
            //cria um objeto de conexão
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexao;
                cmd.CommandText = "UPDATE usuarios SET nome = @nome, email = @email,senha = @senha WHERE id = @id";
                cmd.Parameters.AddWithValue("nome ", objAlterar.NomeUsuario);
                cmd.Parameters.AddWithValue("email", objAlterar.Email);
                cmd.Parameters.AddWithValue("senha", objAlterar.Senha);
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
                cmd.CommandText = "DELETE FROM usuarios WHERE id = " + codExcluir.ToString();
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM usuarios", conexaoString.ConnectionString);

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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM usuarios WHERE nome LIKE '%" + valor + "%'", conexaoString.ConnectionString);

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

        public ModeloUsuario GetRegistro(int id)
        {
            ModeloUsuario objUsuario = new ModeloUsuario();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao;

            try
            {
                cmd.CommandText = "SELECT * FROM usuarios WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.HasRows)
                {
                    registro.Read();
                    objUsuario.Id = Convert.ToInt32(registro["id"]);
                    objUsuario.NomeUsuario = Convert.ToString(registro["nome"]);
                    objUsuario.Email = Convert.ToString(registro["email"]);
                    objUsuario.Senha = Convert.ToString(registro["senha"]);
                }
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return objUsuario;
        }

        public ModeloUsuario GetRegistro(string email)
        {
            ModeloUsuario objUsuario = new ModeloUsuario();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = conexaoString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao;

            try
            {
                cmd.CommandText = "SELECT * FROM usuarios WHERE email = @email";
                cmd.Parameters.AddWithValue("@email", email);
                conexao.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.HasRows)
                {
                    registro.Read();
                    objUsuario.Id = Convert.ToInt32(registro["id"]);
                    objUsuario.NomeUsuario = Convert.ToString(registro["nome"]);
                    objUsuario.Email = Convert.ToString(registro["email"]);
                    objUsuario.Senha = Convert.ToString(registro["senha"]);
                }
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return objUsuario;
        }
    }
}