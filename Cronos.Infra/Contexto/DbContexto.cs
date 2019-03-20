using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Entidades.Tipos;
using Cronos.Infra.Contexto.Map;
using Cronos.Infra.Contexto.Map.Relacionamento;
using Cronos.Infra.Contexto.Map.Tipos;
using Microsoft.EntityFrameworkCore;

namespace Cronos.Infra.Contexto
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options)
            : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.ApplyConfiguration(new LivroMap());

            modelBuilder.ApplyConfiguration(new GastoMap());

            modelBuilder.ApplyConfiguration(new SalararioMap());

            modelBuilder.ApplyConfiguration(new AutentificacaoMap());

            /**
             * Relacionamentos
             */
            modelBuilder.ApplyConfiguration(new LivroUsuarioMap());

            /**
             * Tipos
             */

            modelBuilder.ApplyConfiguration(new LivroCategoriaMap());
        }

        public DbSet<Usuario> Usuario  { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Gasto> Gasto { get; set; }
        public DbSet<Salario> salario { get; set; }
        public DbSet<Autentificacao> Autentificacao { get; set; }

        /**
         * Relacionamentos
         */
        public DbSet<LivroUsuario> LivroUsuario { get; set; }

        /**
         * Tipos
         */
        public DbSet<LivroCategoria> LivroCategoria { get; set; }
    }
}
