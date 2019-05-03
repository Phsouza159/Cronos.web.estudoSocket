using Cronos.Domain.Entidades.Tipos;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.NHibernate.Map.Tipo
{
    public class LivroCategoriaMap : ClassMap<LivroCategoria>
    {
        public LivroCategoriaMap()
        {
            Id(lc => lc.Id);

            Map(lc => lc.DescricaoCategoria).Column("DES_CAT");

            Table("CRONOS_006_CAT_LIVRO");
        }
    }
}
