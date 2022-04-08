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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                DALUsuario dal = new DALUsuario();
                ModeloUsuario objUsuario = dal.GetRegistro(Session["email"].ToString());
                lbNome.Text = objUsuario.NomeUsuario;
                lbEmail.Text = objUsuario.Email;
                ImgUser.ImageUrl = @"IMAGENS\ícone-do-usuário.jpg" + objUsuario.FotoUsuario;
            }
        }
    }
}