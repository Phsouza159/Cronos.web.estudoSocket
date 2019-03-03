using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Cronos.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronos.Infra.Contexto.Map
{
    public class SalararioMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.ToTable("CRONOS_004_SALARIO");

            builder.Ignore(e => e.Notifications);

            builder
                .HasKey(p => p.Id)
                .HasName("ID");

            builder
                .Property(p => p.SoudoBruto)
                .HasColumnName("SOUDO_BRUTO")
                .HasColumnType("double");

            builder
                .Property(p => p.SoudoLiquido)
                .HasColumnName("SOUDO_LIQUIDO")
                .HasColumnType("double");

            builder
                .Property(p => p.DataPagemento)
                .HasColumnName("DTH_PAGAMENTO")
                .HasColumnType("datetime");

            builder
                .Property(p => p.DataInclusao)
                .HasColumnName("DTH_INCLUSAO")
                .HasColumnType("datetime");

            builder
                .Property(p => p.Situacao)
                .HasColumnName("SITUACAO")
                .HasColumnType("bit");

        }
    }
}
