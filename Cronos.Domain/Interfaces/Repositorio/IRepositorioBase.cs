using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity , Id>
        where TEntity: class 
        where Id: struct 
    {
        /// <summary>
        /// Expression contendo propriedades para include
        /// </summary>
        Expression<Func<TEntity, object>>[] includeProperties { get; set; }

        /// <summary>
        /// Auxiliar do include, guardar na memoria propriedade para incluir
        /// </summary>
        void IncludeAux(params Expression<Func<TEntity, object>>[] includeProperties);

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
        TEntity GetById(Id id, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Recuperar todos os elementos
        /// </summary>
        List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Recuperar elementos pela lista de IDS
        /// </summary>
        List<TEntity> GetByList(List<Id> ids, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Incluir propriedades
        /// </summary>
        IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
