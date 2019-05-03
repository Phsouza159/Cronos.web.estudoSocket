using Cronos.Domain.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.NHibernate.Map
{
    public class AutentificacaoMap : ClassMap<Autentificacao>
    {
        public AutentificacaoMap()
        {
            Id(a => a.Id);

            Map(a => a.DataExpiracao);
            Map(a => a.DataInclusao);
            Map(a => a.Situacao);
            Map(a => a.Tokien);

            Table("CRONOS_005_AUTENTIFICACAO");
        }
    }
}
