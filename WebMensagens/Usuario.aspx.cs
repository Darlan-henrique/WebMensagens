using System;
using WebMensagens.DAL;
using WebMensagens.MODELO;

namespace WebMensagens
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            DALUsuario dal = new DALUsuario();
            gvDados.DataSource = dal.Localizar();
            gvDados.DataBind();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            btInserir.Text = "Inserir";
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagem = "";
                DALUsuario dal = new DALUsuario();
                ModeloUsuario objUsuario = new ModeloUsuario();
                objUsuario.NomeUsuario = txtNome.Text;
                objUsuario.Email = txtEmail.Text;
                objUsuario.Senha = txtSenha.Text;
                ModeloUsuario validaEmail = dal.GetRegistro(txtEmail.Text);

                if (btInserir.Text == "Inserir")
                {
                    //inserir
                    if (validaEmail.Id == 0)
                    {

                        dal.Inserir(objUsuario);
                        mensagem = "<script> alert('O Codigo gerado foi:  " + objUsuario.Id.ToString() + "'); </script>";
                        LimpaCampos();
                    }

                    else
                    {
                        mensagem = "<script> alert('Não é possível cadastrar o usuário, pois já existe um usuário cadastrado com esse e-mail.'); </script>";
                    }
                }

                else
                {
                    //Implementar validacao de email
                    objUsuario.Id = Convert.ToInt32(txtId.Text);
                    if ((validaEmail.Id != 0) && (validaEmail.Id != objUsuario.Id))
                    {
                        mensagem = "<script> alert('Não é possível alterar o usuário, pois já existe um usuário cadastrado com esse e-mail.'); </script>";
                    }

                    else
                    {
                        //Alterar
                        dal.Alterar(objUsuario);
                        mensagem = "<script> alert('Registro alterado corretamente!!!'); </script>";
                        LimpaCampos();
                    }

                }
                Response.Write(mensagem);

            }

            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }
            AtualizaGrid();
        }

        protected void gvDados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
            DALUsuario dal = new DALUsuario();
            dal.Excluir(codigo);
            AtualizaGrid();
        }

        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = gvDados.SelectedIndex;
                int codigo = Convert.ToInt32(gvDados.Rows[index].Cells[2].Text);
                DALUsuario dal = new DALUsuario();
                ModeloUsuario objUsuario = dal.GetRegistro(codigo);
                if (objUsuario.Id != 0)
                {
                    txtId.Text = objUsuario.Id.ToString();
                    txtNome.Text = objUsuario.NomeUsuario;
                    txtEmail.Text = objUsuario.Email;
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