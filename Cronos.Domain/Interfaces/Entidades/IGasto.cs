using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Entidades
{
    public interface IGasto : IBase<Gasto>
    {
        int IdUser { get; set; }
        DateTime MesReferencia { get; set; }
        string NomeGasto { get; set; }
        DateTime DataGasto { get; set; }
        double ValorGasto { get; set; }
        int Status { get; set; }
    }
}
