using Cronos.Domain.Entidades;
using Cronos.Domain.Request;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Servico
{
    public interface ILivroServico : INotifiable
    {
        /// <summary>
        /// Adicionar um novo livro
        /// </summary>
        void Add(Livro request);
    }
}
