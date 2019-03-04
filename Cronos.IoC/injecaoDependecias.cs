using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Entidades;
using Cronos.Domain.Interfaces.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Map;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Mapper;
using Cronos.Domain.Servico;
using Cronos.Infra.Repositorio;
using Cronos.Infra.Repositorio.RepositorioBase;
using Microsoft.Extensions.DependencyInjection;

namespace Cronos.IoC
{
    public static class injecaoDependecias
    {
        public static void RegistreService(this IServiceCollection services)
        {
            // DbBase
            services.AddScoped<IRepositorioCommit , RepositorioCommit>();

            // Emtidades 
            services.AddScoped<IUsuario , Usuario>();
            services.AddScoped<ILivro , Livro>();
            services.AddScoped<ISalario , Salario>();
            services.AddScoped<IGasto , Gasto>();

            // Relacionamentos 
            services.AddScoped<ILivroUsuario , LivroUsuario>();

            // Repositorios
            services.AddScoped<IGastoRepositorio , GastoRepositorio>();
            services.AddScoped<IUsuarioRepositorio , UsuarioRepositorio>();
            services.AddScoped<ISalarioRepositorio , SalarioRepositorio>();
            services.AddScoped<ILivroRepositorio , LivroRepositorio>();
            services.AddScoped<ILivroUsuarioRepositorio , LivroUsuarioRepositorio>();
            services.AddScoped<IAutentificacaoRepositorio, AutentificacaoRepositorio>();

            // Servico
            services.AddScoped<IAutentificacaoServico, _AutentificacaoServico>();
            services.AddScoped<ILivroServico, LivroServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();

            // Mapeamento
            services.AddScoped<IMapeamento , Mapeamento>();
        }
    }
}
