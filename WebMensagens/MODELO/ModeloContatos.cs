using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMensagens.MODELO
{
    public class ModeloContatos
    {
        public int Id { get; set; }

        public string NomeContato  { get; set; }

        public string Foto { get; set; }

        public ModeloContatos()
        {
            this.Id = 0;
            this.Foto = "";
            this.NomeContato = "";
        }
    }
}