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
    public partial class PaginaPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            else
            {
                DALUsuario dal = new DALUsuario();
                ModeloUsuario objUsuario = dal.GetRegistro(Session["email"].ToString());
            }
        }
    }
}