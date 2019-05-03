using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface IAutentificacaoRepositorio : INotifiable, IRepositorioBase<Autentificacao , int> 
    {
        Usuario GetTokien(string Tokien);
        bool ValidarTokien(string Tokien);
    }
}
