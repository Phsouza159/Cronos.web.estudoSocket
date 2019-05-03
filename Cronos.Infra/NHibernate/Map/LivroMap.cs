using System;
using System.Collections.Generic;
using System.Text;
using Cronos.Domain.Entidades;
using FluentNHibernate.Automapping;
using FluentNHibernate.Mapping;

namespace Cronos.Infra.NHibernate.Map
{
    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Id(lv => lv.Id);

            

            Map(lv => lv.IdCategoria).Column("ID_CAT");
            Map(lv => lv.NumPaginas).Column("NUM_PGS");
            Map(lv => lv.Situacao).Column("SITUACAO");
            //Map(lv => lv.Status).Column("");
            Map(lv => lv.Titulo).Column("TITULO");
            Map(lv => lv.Valor).Column("VALOR");
            Map(lv => lv.Autor).Column("AUTOR");
            Map(lv => lv.DataInclusao).Column("DTH_INCLUSAO");

            Table("cronos_002_livro");
        }
    }
}
