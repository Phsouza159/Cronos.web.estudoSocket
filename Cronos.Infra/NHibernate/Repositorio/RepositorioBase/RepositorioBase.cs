using Cronos.Domain.Interfaces.Repositorio;
using NHibernate;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cronos.Infra.NHibernate.Repositorio
{
    public class BaseRepositorio<TEntity> : Notifiable, IRepositorioBase<TEntity, int>
        where TEntity : class
    {
        public Expression<Func<TEntity, object>>[] includeProperties { get ; set; }

        public virtual bool Add(TEntity Object)
        {
            bool salve = false;

            using (ISession session = DbContexto.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(Object);
                        salve = true;
                    }
                    catch (Exception e)
                    {
                        this.AddNotification("Add entidade base", e.Message);
                    }
                }
            }
            return salve;
        }

        public virtual bool UpDate(TEntity Object)
        {
            bool salve = false;

            using (ISession session = DbContexto.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(Object);
                        salve = true;
                    }
                    catch (Exception e)
                    {
                        this.AddNotification("Update entidade base", e.Message);
                    }
                }
            }
            return salve;
        }

        public virtual List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (ISession session = DbContexto.AbrirSession())
            {
                try
                {
                    return (from e in session.Query<TEntity>() select e).ToList();
                    //session.Get<TEntity>(TEntity.Equals);
                }
                catch (Exception e)
                {
                    this.AddNotification("Listar entidade base", e.Message);
                    return new List<TEntity>();
                }
            }
        }

        public virtual TEntity GetById(int id , params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (ISession session = DbContexto.AbrirSession())
            {
                try
                {
                    return session.Get<TEntity>(id);
                }
                catch (Exception e)
                {
                    this.AddNotification("Buscar entidade base", e.Message);
                    return null;
                }
            }
        }

        public virtual List<TEntity> GetByList(List<int> ids , params Expression<Func<TEntity, object>>[] includeProperties)
        {
            List<TEntity> list = new List<TEntity>();

            ids.ForEach( id => {
                list.Add(this.GetById(id));
            });

            return list;
        }

        public virtual bool IdExiste(int id)
        {
            using (ISession session = DbContexto.AbrirSession())
            {
                try
                {
                    TEntity obj = session.Get<TEntity>(id);
                    return (obj == null);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public virtual bool Inativar(int id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void IncludeAux(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            this.includeProperties = includeProperties;
        }
    }
}
