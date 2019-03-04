using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cronos.Infra.Repositorio.RepositorioBase
{
    public class RepositorioBase<TEntity, Id> : Notifiable, IRepositorioBase<TEntity, Id>
        where TEntity : EntidadeBase
        where Id : struct
    {
        protected DbContexto _db { get; set; }

        public RepositorioBase(DbContexto _db)
        {
            this._db = _db;
        }

        public bool Add(TEntity Object)
        {
            try { 
                _db.Set<TEntity>().Add(Object);
                return true;
            }
            catch (Exception e)
            {
                this.AddNotification("Adicionar objeto", "Não foi possivel adicionar o objeto :: " + e.Message);
                return false;
            }
        }

        public List<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(Id id)
        {
            return _db.Set<TEntity>().Where(e => e.Id.Equals(id)).First();
        }

        public List<TEntity> GetByList(List<Id> ids)
        {
            List<TEntity> ls = new List<TEntity>();

            foreach (var id in ids)
                ls.Add(_db.Set<TEntity>().Where(e => e.Id.Equals(id)).First());

            return ls;
        }

        public bool IdExiste(Id id)
        {
            return _db.Set<TEntity>().Any(e => e.Id.Equals(id));
        }

        public bool Inativar(Id id)
        {
            TEntity entity = this.GetById(id);
            entity.Situacao = false;
            return this.UpDate(entity);
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
                return false;
            }
        }
    }
}
