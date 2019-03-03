using Cronos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Cronos.Infra.Contexto.Map
{
    public class AutentificacaoMap : IEntityTypeConfiguration<Autentificacao>
    {
        public void Configure(EntityTypeBuilder<Autentificacao> builder)
        {
            builder.ToTable("CRONOS_005_AUTENTIFICACAO");

            builder
                .HasKey(p => p.Id)
                .HasName("ID");

            builder
                .Property(p => p.Tokien)
                .HasColumnName("TOKIEN")
                .HasColumnType("varchar(255)");

            builder
                .Property(p => p.DataExpiracao)
                .HasColumnName("DTH_EXPIRACAO")
                .HasColumnType("DATETIME");
        }
    }
}
