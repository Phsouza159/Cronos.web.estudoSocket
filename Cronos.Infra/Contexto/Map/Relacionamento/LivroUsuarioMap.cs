using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Cronos.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cronos.Domain.Entidades.Relacionamentos;

namespace Cronos.Infra.Contexto.Map.Relacionamento
{
    public class LivroUsuarioMap : IEntityTypeConfiguration<LivroUsuario>
    {
        public void Configure(EntityTypeBuilder<LivroUsuario> builder)
        {
            builder.ToTable("CRONOS_101_USUARIO_LIVRO");

            builder.Ignore(e => e.Notifications);

            builder
                .Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("int");

            builder
                .Property(p => p.IdUsuario)
                .HasColumnName("ID_USUARIO")
                .HasColumnType("int");

            builder
                .Property(p => p.IdLivro)
                .HasColumnName("ID_LIVRO")
                .HasColumnType("int");

            builder
                .Property(p => p.DataInclusao)
                .HasColumnName("DTH_INCLUSAO")
                .HasColumnType("datetime");

            builder
                .Property(p => p.Situacao)
                .HasColumnName("SITUACAO")
                .HasColumnType("bit");

            builder
                .HasOne(p => p.Livro)
                .WithMany(p => p.LivroUsuario)
                .HasForeignKey(p => p.IdLivro);

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.LivroUsuario)
                .HasForeignKey(p => p.IdUsuario);
        }
    }
}
