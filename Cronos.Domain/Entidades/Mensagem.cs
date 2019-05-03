using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Entidades
{
    public class Mensagem : EntidadeBase , IMensagem
    {
        public Mensagem()
        {

        }

        public Mensagem Valid()
        {
            return this;
        }

        public int? IdTo { get; set; }
        public int? IdFrom { get; set; }
        public string Texto { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime? DataLida { get; set; }

        public virtual Usuario UsuarioTo { get; set; }
        public virtual Usuario UsuarioFrom { get; set; }

    }
}
