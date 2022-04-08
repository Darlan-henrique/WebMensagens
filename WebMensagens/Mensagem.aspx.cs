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
    public partial class Mensagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            if (!IsPostBack)
            {
                AtualizaContato();
                AtualizaCategoria();

            }

        }

        public void LimparCampos()
        {
            txtId.Text = "";
            txtMsg.Text = "";
            btInserir.Text = "Inserir";
        }
        public void AtualizaGrid()
        {
            DALMensagem dal = new DALMensagem();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }

        public void AtualizaContato()
        {
            DALContatos dal = new DALContatos();
            ddlCont.DataSource = dal.Localizar();
            ddlCont.DataTextField = "nome";
            ddlCont.DataValueField = "id";
            ddlCont.DataBind();
        }

        public void AtualizaCategoria()
        {
            DALCategoria dal = new DALCategoria();
            ddlCat.DataSource = dal.Localizar();
            ddlCat.DataTextField = "categoria";
            ddlCat.DataValueField = "id";
            ddlCat.DataBind();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                String mensagem = "";
                DALMensagem dal = new DALMensagem();
                ModeloMensagem objMensagem = new ModeloMensagem();
                objMensagem.Texto = txtMsg.Text;
                objMensagem.CdContato = Convert.ToInt32(ddlCont.SelectedValue);
                objMensagem.Cdcategoria = Convert.ToInt32(ddlCat.SelectedValue);

                if (btInserir.Text == "Inserir")
                {
                    //inserir
                    dal.Inserir(objMensagem);
                    mensagem = "<script>  ShowMsg('Cadastro',' Realizado com sucesso!! " + "'); </script>";
                }
                else
                {
                    //alterar
                    objMensagem.Id = Convert.ToInt32(txtId.Text);
                    dal.Alterar(objMensagem);
                    mensagem = "<script> ShowMsg('Registro','alterado corretamente!!!'); </script>";
                }
                Modal.Controls.Add(new LiteralControl(mensagem));
                LimparCampos();
            }

            catch (Exception erro)
            {
                String mensagem1 = ("<script> ShowMsg('Cadastro','" + erro.Message + "'); </script>");
                Modal.Controls.Add(new LiteralControl(mensagem1));
            }
            AtualizaGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvDados.SelectedIndex;
            int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALMensagem dal = new DALMensagem();
            ModeloMensagem objMensagem = dal.GetRegistro(codigo);

            if (objMensagem.Id != 0)
            {
                txtId.Text = objMensagem.Id.ToString();
                txtMsg.Text = objMensagem.Texto;
                ddlCont.SelectedValue = objMensagem.CdContato.ToString();
                ddlCat.SelectedValue = objMensagem.Cdcategoria.ToString();
                btInserir.Text = "Alterar";

            }
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALMensagem objMensagem = new DALMensagem();
            objMensagem.Excluir(codigo);
            AtualizaGrid();
        }
    }
}