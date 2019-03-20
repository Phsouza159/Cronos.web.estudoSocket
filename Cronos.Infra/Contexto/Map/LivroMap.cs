using Cronos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cronos.Infra.Contexto.Map
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("cronos_002_livro");

            builder.Ignore(e => e.Notifications);
            builder.Ignore(e => e.Status);

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder
                .Property(p => p.Titulo)
                .HasColumnName("TITULO")
                .HasColumnType("varchar(35)");

            builder
                .Property(p => p.Autor)
                .HasColumnName("AUTOR")
                .HasColumnType("varchar(35)");

            builder
                .Property(p => p.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("double");

            builder
                .Property(p => p.NumPaginas)
                .HasColumnName("NUM_PGS")
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
                .Property(p => p.IdCategoria)
                .HasColumnName("ID_CAT")
                .HasColumnType("int");

            builder
                .HasOne(p => p.LivroCategoria)
                .WithMany(p => p.Livro)
                .HasForeignKey(p => p.IdCategoria);
        }
    }
}
