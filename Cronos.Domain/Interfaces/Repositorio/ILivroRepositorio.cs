using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface ILivroRepositorio : INotifiable, IRepositorioBase<Livro , int>
    {
        Interfaces.NHibernite.ILivroRepositorio _Hibernite { get; set; }
    }
}
