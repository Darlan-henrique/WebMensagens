using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMensagens.MODELO
{
    public class ModeloCategoria
    {
        public int Id { get; set; }

        public string NomeCategoria { get; set; }

        public ModeloCategoria()
        {
            this.Id = 0;
            this.NomeCategoria = "";
        }
    }
}