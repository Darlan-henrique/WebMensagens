using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMensagens.MODELO
{
    public class ModeloUsuario
    {
        public int Id { get; set; }

        public string NomeUsuario { get; set; }

        public string Email{ get; set; }

        public string Senha { get; set; }

        public string FotoUsuario { get; set; }

        public ModeloUsuario()
        {
            this.Id = 0;
            this.NomeUsuario = "";
            this.Email = "";
            this.Senha = "";
            this.FotoUsuario = "";
        }
    }
}