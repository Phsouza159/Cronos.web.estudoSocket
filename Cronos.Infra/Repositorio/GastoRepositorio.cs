using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;

namespace Cronos.Infra.Repositorio
{
    public class GastoRepositorio : RepositorioBase<Gasto, int>, IGastoRepositorio
    {
        public GastoRepositorio(DbContexto _db) : base(_db)
        {
        }
    }
}
