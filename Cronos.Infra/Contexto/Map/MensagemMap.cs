using Cronos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cronos.Infra.Contexto.Map
{
    public class MensagemMap : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.ToTable("CRONOS_007_MENSAGEM");

            builder.Ignore(e => e.Notifications);
            builder.Ignore(e => e.UsuarioFrom);
            builder.Ignore(e => e.UsuarioTo);

            builder
                .HasKey(p => p.Id)
                .HasName("ID");

            builder
                .Property(p => p.IdTo)
                .HasColumnName("ID_TO")
                .HasColumnType("int");

            builder
                .Property(p => p.IdFrom)
                .HasColumnName("ID_FROM")
                .HasColumnType("int");

           builder
                .Property(p => p.Texto)
                .HasColumnName("TEXTO")
                .HasColumnType("varchar(255)");

            builder
                .Property(p => p.Situacao)
                .HasColumnName("SIT")
                .HasColumnType("bit");

            builder
                .Property(p => p.DataEnvio)
                .HasColumnName("DTH_ENVIO")
                .HasColumnType("datetime");

            builder
                .Property(p => p.DataLida)
                .HasColumnName("DTH_LIDA")
                .HasColumnType("datetime");

            builder
                .Property(p => p.DataInclusao)
                .HasColumnName("DTH_INCLUSAO")
                .HasColumnType("datetime");

            builder
                .HasOne(p => p.UsuarioTo)
                .WithMany(p => p.Mensagens)
                .HasForeignKey(p => p.IdTo);

           // builder
           //     .HasOne(e => e.UsuarioFrom)
           //     .WithMany(e => e.Mensagens);
        }
    }
}
