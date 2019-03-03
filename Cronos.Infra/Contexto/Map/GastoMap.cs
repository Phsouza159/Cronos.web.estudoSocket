using Cronos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronos.Infra.Contexto.Map
{
    public class GastoMap : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.ToTable("CRONOS_003_GASTO");

            builder.Ignore(e => e.Notifications);

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder
                .Property(p => p.IdUser)
                .HasColumnName("ID_USUARIO")
                .HasColumnType("int");

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.Gasto)
                .HasForeignKey(p => p.IdUser);

            builder
                .Property(p => p.MesReferencia)
                .HasColumnName("MES_REFERENCIA")
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