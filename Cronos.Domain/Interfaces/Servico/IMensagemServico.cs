using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Servico
{
    public interface IMensagemServico : INotifiable
    {
        /// <summary>
        /// Gravar uma nova mensagem
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="Commit"></param>
        /// <returns></returns>
        bool Send(Mensagem mensagem , bool Commit = false);

        /// <summary>
        /// Gravar mensagens como lidas
        /// </summary>
        /// <param name="mensagens"></param>
        /// <param name="Commit"></param>
        /// <returns></returns>
        bool GravarMensagemComoLida(List<Mensagem> mensagens , bool Commit = false);

        /// <summary>
        /// Recuperar Mensagens do Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        List<Mensagem> RecuperarMensagensUsuario(Usuario usuario);

        /// <summary>
        /// Recuperar mensagens
        /// </summary>
        List<Mensagem> RecuperarMensagemUsuarioNaoLidas(Usuario usuario);
    }
}
