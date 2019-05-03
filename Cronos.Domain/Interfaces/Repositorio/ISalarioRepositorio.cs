using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface ISalarioRepositorio : INotifiable, IRepositorioBase<Salario, int>
    {
    }
}
