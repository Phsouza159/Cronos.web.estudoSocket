using Cronos.Domain.Entidades.Relacionamentos;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.NHibernate.Map.Relacionameto
{
    public class LivroUsuarioMap : ClassMap<LivroUsuario>
    {
        public LivroUsuarioMap()
        {
            Id(lu => lu.Id);

            Map(lu => lu.DataInclusao);
            Map(lu => lu.Fim);
            Map(lu => lu.IdLivro);
            Map(lu => lu.IdUsuario);
            Map(lu => lu.Inicio);
            Map(lu => lu.Lido);
            Map(lu => lu.Situacao);

            Table("CRONOS_101_USUARIO_LIVRO");
        }
    }
}
