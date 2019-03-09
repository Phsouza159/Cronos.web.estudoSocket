using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;

namespace Cronos.Domain.Interfaces.Servico
{
    public interface IUsuarioServico : INotifiable
    {
        void AddUser(Usuario usuario);
    }
}
