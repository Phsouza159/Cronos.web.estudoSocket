using System;
using System.Collections.Generic;
using System.Text;
using Cronos.Domain.Entidades.Tipos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronos.Infra.Contexto.Map.Tipos
{
    public class LivroCategoriaMap : IEntityTypeConfiguration<LivroCategoria>
    {
        public void Configure(EntityTypeBuilder<LivroCategoria> builder)
        {
            builder.ToTable("CRONOS_006_CAT_LIVRO");

            builder
                .HasKey(p => p.Id)
                .HasName("ID");

            builder.Property(p => p.DescricaoCategoria)
                .HasColumnName("DES_CAT")
                .HasColumnType("varchar(25)");
        }
    }
}
