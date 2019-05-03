using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using prmToolkit.NotificationPattern;

namespace Cronos.Domain.Interfaces.NHibernite
{
    public interface ILivroRepositorio : INotifiable, IRepositorioBase<Livro , int>
    {
    }
}
