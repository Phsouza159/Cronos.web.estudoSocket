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

        /// <summary>
        /// Vincular livro a um usuario
        /// </summary>
        void Vincular(int IdLivro, int IdUser);

        /// <summary>
        /// Recupearar Lista de Livros pelo vinculo do usuario 
        /// </summary>
        List<Livro> GetByLivroUsuario(int IdUSer);
    }
}
