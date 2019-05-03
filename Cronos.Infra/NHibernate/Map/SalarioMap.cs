using Cronos.Domain.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.NHibernate.Map
{
    public class SalarioMap : ClassMap<Salario>
    {
        public SalarioMap()
        {
            Id(sl => sl.Id);

            Map(sl => sl.DataInclusao);
            Map(sl => sl.DataPagemento);
            Map(sl => sl.Situacao);
            Map(sl => sl.SoudoBruto);
            Map(sl => sl.SoudoLiquido);

            Table("CRONOS_004_SALARIO");
        }
    }
}
