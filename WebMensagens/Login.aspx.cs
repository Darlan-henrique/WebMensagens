using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMensagens.DAL;
using WebMensagens.MODELO;

namespace WebMensagens
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btlogar_Click(object sender, EventArgs e)
        {
            string email = txbLogin.Text;
            string senha = txbSenha.Text;

            DALUsuario dal = new DALUsuario();
            ModeloUsuario objUsuario = dal.GetRegistro(email);
            if (email == objUsuario.Email && senha == objUsuario.Senha && objUsuario.Email != string.Empty && objUsuario.Senha != string.Empty)
            {
                Session["id"] = objUsuario.Id;
                Session["nome"] = objUsuario.NomeUsuario;
                Session["email"] = objUsuario.Email;
                Response.Redirect("~/Default.aspx");

            }

            else
            {
                String mensagem = "<script> alert('Login ou senha incorretos!!!!'); </script>";
                Response.Write(mensagem);
            }

        }
    }
}