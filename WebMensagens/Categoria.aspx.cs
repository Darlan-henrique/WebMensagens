using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using WebMensagens.DAL;
using WebMensagens.MODELO;

namespace WebMensagens
{
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            DALCategoria dal = new DALCategoria();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }

        public void LimpaCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            btInserir.Text = "Inserir";
        }
        protected void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagem = "";
                DALCategoria dal = new DALCategoria();
                ModeloCategoria objCategoria = new ModeloCategoria();
                objCategoria.NomeCategoria = txtNome.Text;

                if (btInserir.Text == "Inserir")
                {
                    //Inserir
                    dal.Inserir(objCategoria);
                    mensagem = "<script>  ShowMsg('Cadastro',' Realizado com sucesso!! " + "'); </script>";

                }

                else
                {
                    //Alterar
                    objCategoria.Id = Convert.ToInt32(txtId.Text);
                    dal.Alterar(objCategoria);
                    mensagem = "<script> ShowMsg('Registro','alterado corretamente'); </script>";
                }
                Modal.Controls.Add(new LiteralControl(mensagem));
                LimpaCampos();
            }
            catch (Exception erro)
            {
                String mensagem1 = ("<script> ShowMsg('Cadastro','" + erro.Message + "'); </script>");
                Modal.Controls.Add(new LiteralControl(mensagem1));
            }
            AtualizaGrid();
        }
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALCategoria dal = new DALCategoria();
            dal.Excluir(codigo);
            AtualizaGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
            {
                int index = gvDados.SelectedIndex;
                int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
                DALCategoria dal = new DALCategoria();
                ModeloCategoria objCategoria = dal.GetRegistro(codigo);

                if (objCategoria.Id != 0)
                {
                    txtId.Text = objCategoria.Id.ToString();
                    txtNome.Text = objCategoria.NomeCategoria;
                    btInserir.Text = "Alterar";
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

       
    }
}