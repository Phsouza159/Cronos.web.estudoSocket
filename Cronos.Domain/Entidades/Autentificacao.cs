using Cronos.Domain.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Entidades
{
    public class Autentificacao : IAutentificacao
    {
        public Autentificacao(int id, string tokien, DateTime dataExpiracao)
        {
            Id = id;
            Tokien = tokien;
            DataExpiracao = dataExpiracao;
        }

        public int Id { get ; set ; }
        public string Tokien { get ; set ; }
        public DateTime DataExpiracao { get ; set ; }

        public virtual Usuario Usuario { get; set; }
    }
}
