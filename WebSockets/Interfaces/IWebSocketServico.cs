using Cronos.Domain.Interfaces.Servico;
using Cronos.Infra.Contexto;

namespace WebSockets.ws.Interfaces
{
    public interface IWebSocketServico
    {
        DbContexto _db { get; set; }
        IMensagemServico mensagemServico { get; set; }
        IAutentificacaoServico autentificacaoServico { get; set; }
        ILivroServico livroServico { get; set; }
    }
}
