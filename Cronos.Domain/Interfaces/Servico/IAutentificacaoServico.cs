using Cronos.Domain.Entidades;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Servico
{
    public interface IAutentificacaoServico : INotifiable
    {
        /// <summary>
        /// Efetuar login e retornar um tokien
        /// </summary>
        string Login(string User, string Senha);

        /// <summary>
        /// Validar tokein
        /// </summary>
        string ValidarTokien(string Tokien);

        /// <summary>
        /// Gerar tokien
        /// </summary>
        string GerarTokien(int IdUser);
        string GerarTokien(Usuario Usuario);
    }
}
