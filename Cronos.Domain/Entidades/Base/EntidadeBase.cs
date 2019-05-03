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
        public virtual int Id { get; set; }
        public virtual bool Situacao { get; set; }
        public virtual DateTime DataInclusao { get; set; }

    }
}
