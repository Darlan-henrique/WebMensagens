using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMensagens.MODELO
{
    public class ModeloMensagem
    {
        public int Id { get; set; }

        public string Texto { get; set; }

        public int CdContato { get; set; }

        public int Cdcategoria  { get; set; }

        public ModeloMensagem()
        {
            this.Id = 0;
            this.Texto = "";
            this.CdContato = 0;
            this.Cdcategoria = 0;
        }
    }
}