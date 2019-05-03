using Cronos.Domain.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.NHibernate.Map
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(u => u.Id);

            Map(u => u.DataInclusao);
            Map(u => u.Email);
            Map(u => u.Gasto);
            Map(u => u.IdSalario);
            Map(u => u.IdTokien);
            Map(u => u.Nome);
            Map(u => u.Password);
            Map(u => u.Situacao);
            Map(u => u.Sobrenome);
            Map(u => u.User);

            Table("CRONOS_001_USUARIO");
        }
    }
}
