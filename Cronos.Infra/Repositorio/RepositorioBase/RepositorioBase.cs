using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Resources;
using Cronos.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using prmToolkit.NotificationPattern.Extensions;

namespace Cronos.Infra.Repositorio.RepositorioBase
{
    public class RepositorioBase<TEntity, Id> : Notifiable, IRepositorioBase<TEntity, Id>
        where TEntity : EntidadeBase
        where Id : struct
    {
        protected DbContexto _db { get; set; }

        public Expression<Func<TEntity, object>>[] includeProperties { get; set; }

        public RepositorioBase(DbContexto _db)
        {
            this._db = _db;
        }

        public void IncludeAux( params Expression<Func<TEntity, object>>[] includeProperties)
        {
            this.includeProperties = includeProperties;
        }

        public bool Add(TEntity Object)
        {
            try { 
                _db.Set<TEntity>().Add(Object);
                return true;
            }
            catch (Exception e)
            {
                this.AddNotification("Add Entidadde", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
                return false;
            }
        }

        public List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                if (includeProperties.Any()) {
                    IQueryable<TEntity> queryable = this.Include(_db.Set<TEntity>(), includeProperties);
                    return queryable.ToList();
                }
                return _db.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {
                this.AddNotification("GetAll Entidadde", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
                return null;
            }
        }

        public TEntity GetById(Id id , params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try { 
                if (includeProperties.Any())
                {
                    IQueryable<TEntity> queryable = this.Include( _db.Set<TEntity>() , includeProperties);
                    return queryable.First(e => e.Id.Equals(id));
                }
                return _db.Set<TEntity>().Find(id);

            }
            catch (Exception e)
            {
                this.AddNotification("GetById Entidadde", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
                return null;
            }
        }

        public List<TEntity> GetByList(List<Id> ids, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                List<TEntity> ls = new List<TEntity>();
                ids.ForEach( id =>
                {
                    ls.Add(_db.Set<TEntity>().Where(e => e.Id.Equals(id)).First());
                });
                return ls;
            }
            catch(Exception e)
            {
                this.AddNotification("GetByList Entidadde", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
                return null;
            }
        }

        public bool IdExiste(Id id)
        {
            return _db.Set<TEntity>().Any(e => e.Id.Equals(id));
        }

        public bool Inativar(Id id)
        {
            try { 
                TEntity entity = this.GetById(id);
                entity.Situacao = false;
                return this.UpDate(entity);
            }
            catch(Exception e)
            {
                this.AddNotification("UpDate Entidadde", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
                return false;
            }
        }

        public bool Remove(Id id)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(TEntity Object)
        {
            try { 
                _db.Set<TEntity>().Update(Object);
                return true;
            }
            catch (Exception e)
            {
                this.AddNotification("UpDate Entidadde", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
                return false;
            }
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        public IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }


    }
}
