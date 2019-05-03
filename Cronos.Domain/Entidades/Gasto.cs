using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Entidades
{
    public class Gasto : EntidadeBase, IGasto
    {
        public Gasto()
        {

        }

        public virtual int IdUser { get; set; }
        public virtual DateTime MesReferencia { get ; set ; }
        public virtual string NomeGasto { get ; set ; }
        public virtual DateTime DataGasto { get ; set ; }
        public virtual double ValorGasto { get ; set ; }
        public virtual int Status { get ; set ; }

        public virtual Gasto Valid()
        {
            return this;
        }

        public virtual Usuario Usuario { get; set; }
    }
}
