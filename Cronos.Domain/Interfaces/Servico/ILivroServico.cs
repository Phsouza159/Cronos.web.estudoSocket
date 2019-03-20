using Cronos.Domain.Entidades;
using Cronos.Domain.Request;
using Cronos.Domain.Response;
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
        /// Editar um livro
        /// </summary>
        Livro Edit(Livro request);

        /// <summary>
        /// Recupearar Lista de Livros pelo vinculo do usuario 
        /// </summary>
        List<ListLivroResponse> GetByLivroUsuario(int IdUSer);
    }
}
