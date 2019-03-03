using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity , Id> : INotifiable
        where TEntity: class 
        where Id: struct 
    {
        /// <summary>
        /// Verificar se o elemento existe pelo seu ID
        /// </summary>
        bool IdExiste(Id id);

        /// <summary>
        /// Adicionar um objeto ao contexto
        /// </summary>
        bool Add(TEntity Object);

        /// <summary>
        /// Remover um objeto pelo seu ID
        /// </summary>
        bool Remove(Id id);

        /// <summary>
        /// Inativar um objeto pelo seu ID
        /// </summary>
        bool Inativar(Id id);

        /// <summary>
        /// Atualizar um objeto
        /// </summary>
        bool UpDate(TEntity Object);

        /// <summary>
        /// Buscar objeto pelo seu ID
        /// </summary>
        TEntity GetById(Id id);

        /// <summary>
        /// Recuperar todos os elementos
        /// </summary>
        List<TEntity> GetAll();

        /// <summary>
        /// Recuperar elementos pela lista de IDS
        /// </summary>
        List<TEntity> GetByList(List<Id> ids);
    }
}
