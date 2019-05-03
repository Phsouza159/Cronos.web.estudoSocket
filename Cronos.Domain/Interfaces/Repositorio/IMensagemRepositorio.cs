using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface IMensagemRepositorio : IRepositorioBase<Mensagem , int> , INotifiable
    {

        bool Commit();

        /// <summary>
        /// Recuperar Mensagens do usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        List<Mensagem> RecuperarMensagensUsuario(int idUsuario, params Expression<Func<Mensagem, object>>[] includeProperties);

        /// <summary>
        /// Recuperar mensagens nao lidas 
        /// </summary>
        List<Mensagem> RecuperarMensagensNaoLidas(int idUsuario , params Expression<Func<Mensagem, object>>[] includeProperties);

        /// <summary>
        /// Gravar mensagens como não lidas
        /// </summary>
        /// <param name="mensagens"></param>
        /// <returns></returns>
        bool GravarMensagensComoLidas(List<Mensagem> mensagens);
    }
}
