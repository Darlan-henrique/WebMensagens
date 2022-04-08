using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMensagens.DAL;
using WebMensagens.MODELO;

namespace WebMensagens
{
    public partial class Contatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            DALContatos dal = new DALContatos();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }

        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            btInserir.Text = "Inserir";
        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String caminho = Server.MapPath(@"IMAGENS\CONTATOS\");
            int index = Convert.ToInt32(e.RowIndex);
            int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALContatos dal = new DALContatos();
            //verificar se existe foto existe e deletar
            ModeloContatos uold = dal.GetRegistro(codigo);
            if(uold.Foto != "")
            {
                File.Delete(caminho + uold.Foto);
            }
            dal.Excluir(codigo);
            this.LimparCampos();
            AtualizaGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = gvDados.SelectedIndex;
                int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
                DALContatos dal = new DALContatos();
                ModeloContatos objContatos = dal.GetRegistro(codigo);

                if (objContatos.Id != 0)
                {
                    txtId.Text = objContatos.Id.ToString();
                    txtNome.Text = objContatos.NomeContato;
                    btInserir.Text = "Alterar";
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                String caminho = Server.MapPath(@"IMAGENS\CONTATOS\");
                String mensagem = "";
                DALContatos dal = new DALContatos();
                ModeloContatos objContatos = new ModeloContatos();
                objContatos.NomeContato = txtNome.Text;
                //faz o upload da foto e salva o nome no obj
                if (fuFoto.PostedFile.FileName != "")
                {
                    objContatos.Foto = DateTime.Now.Millisecond.ToString() + fuFoto.PostedFile.FileName;
                    String img = caminho + objContatos.Foto;
                    fuFoto.PostedFile.SaveAs(img);
                }

                if (btInserir.Text == "Inserir")
                {
                    //Inserir
                    dal.Inserir(objContatos);
                    mensagem = "<script>  ShowMsg('Cadastro',' Realizado com sucesso!! " + "'); </script>";

                }

                else
                {
                    //Alterar
                    objContatos.Id = Convert.ToInt32(txtId.Text);
                    //verificar se existe foto existe deletar
                    ModeloContatos uold = dal.GetRegistro(objContatos.Id);
                    if (uold.Foto != "")
                    {
                        File.Delete(caminho + uold.Foto);
                    }
                    dal.Alterar(objContatos);
                    mensagem = mensagem = "<script>  ShowMsg('Registro',' alterado corretamente " + "'); </script>";
                }
                Modal.Controls.Add(new LiteralControl(mensagem));
                this.LimparCampos();
            }
            catch (Exception erro)
            {
                String mensagem1 = ("<script> ShowMsg('Cadastro','" + erro.Message + "'); </script>");
                Modal.Controls.Add(new LiteralControl(mensagem1));
            }
            AtualizaGrid();
        }
    }
}