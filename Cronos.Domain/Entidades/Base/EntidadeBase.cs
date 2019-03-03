using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cronos.Domain.Entidades.Base
{
    public abstract class EntidadeBase : Notifiable
    {
        public EntidadeBase()
        {

        }

        protected EntidadeBase(bool situacao, DateTime dataInclusao)
        {
            Situacao = situacao;
            DataInclusao = dataInclusao;
        }

        [Key]
        public int Id { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataInclusao { get; set; }

    }
}
