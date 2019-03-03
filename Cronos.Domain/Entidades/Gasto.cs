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

        public int IdUser { get; set; }
        public DateTime MesReferencia { get ; set ; }
        public string NomeGasto { get ; set ; }
        public DateTime DataGasto { get ; set ; }
        public double ValorGasto { get ; set ; }
        public int Status { get ; set ; }

        public Gasto Valid()
        {
            return this;
        }

        public virtual Usuario Usuario { get; set; }
    }
}
