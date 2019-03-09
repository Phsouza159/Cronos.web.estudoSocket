using Cronos.Domain.Entidades;
using Cronos.Domain.Response;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Servico
{
    public interface IAutentificacaoServico : INotifiable
    {
        /// <summary>
        /// Recuperar Usuario pelo Tokien ativo
        /// </summary>
        Usuario RecuperarPeloTokien(string tokien);

        /// <summary>
        /// Efetuar login e retornar um tokien
        /// </summary>
        UserResponse Login(string User, string Senha);

        /// <summary>
        /// Validar tokein
        /// </summary>
        string ValidarTokien(string Tokien);

        /// <summary>
        /// Efetuar logoff
        /// </summary>
        bool LogOff(string Tokien);

        /// <summary>
        /// Gerar tokien
        /// </summary>
        string GerarTokien(int IdUser);
        string GerarTokien(Usuario Usuario);
    }
}
