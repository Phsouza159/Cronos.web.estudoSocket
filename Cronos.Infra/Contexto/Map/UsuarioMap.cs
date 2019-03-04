using Cronos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronos.Infra.Contexto.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("CRONOS_001_USUARIO");

            builder
                .Ignore(e => e.Notifications);

            builder
                .Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("int");

            builder
                .Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(25)");

            builder
                .Property(p => p.User)
                .HasColumnName("NM_USER")
                .HasColumnType("varchar(25)");

            builder
                .Property(p => p.Sobrenome)
                .HasColumnName("SOBRENOME")
                .HasColumnType("varchar(25)");

            builder
                .Property(p => p.IdSalario)
                .HasColumnName("ID_SALARIO")
                .HasColumnType("int");

            builder
                .HasOne(p => p.Salario)
                .WithOne(p => p.Usuario);

            builder
                .Property(p => p.IdTokien)
                .HasColumnName("ID_TOKIEN")
                .HasColumnType("int");

            builder
                .HasOne(p => p.Autentificacao)
                .WithOne(p => p.Usuario);

            builder
                .Property(p => p.Password)
                .HasColumnName("SENHA")
                .HasColumnType("varchar(255)");

            builder
                .Property(p => p.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(50)");

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
