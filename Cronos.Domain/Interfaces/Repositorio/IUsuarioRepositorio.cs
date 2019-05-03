using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio : INotifiable , IRepositorioBase<Usuario , int>
    {
        Usuario Login(string User, string Senha);
    }
}
