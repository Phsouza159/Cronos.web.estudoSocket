using Cronos.Domain.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.NHibernate.Map
{
    public class GastoMap : ClassMap<Gasto>
    {
        public GastoMap()
        {
            Id( g => g.Id);

            Map(g => g.DataGasto);
            Map(g => g.DataInclusao);
            Map(g => g.IdUser);
            Map(g => g.MesReferencia);
            Map(g => g.NomeGasto);
            Map(g => g.Situacao);
            Map(g => g.Status);
            Map(g => g.ValorGasto);

            Table("CRONOS_003_GASTO");
        }
    }
}
