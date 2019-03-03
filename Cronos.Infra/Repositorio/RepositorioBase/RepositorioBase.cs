using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Cronos.Infra.Repositorio.RepositorioBase
{
    public class RepositorioBase<TEntity, Id> : Notifiable, IRepositorioBase<TEntity, Id>
        where TEntity : class
        where Id : struct
    {
        private DbContexto _db { get; set; }

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
            throw new NotImplementedException();
        }

        public TEntity GetById(Id id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetByList(List<Id> ids)
        {
            throw new NotImplementedException();
        }

        public bool IdExiste(Id id)
        {
            throw new NotImplementedException();
        }

        public bool Inativar(Id id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Id id)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(TEntity Object)
        {
            throw new NotImplementedException();
        }
    }
}
