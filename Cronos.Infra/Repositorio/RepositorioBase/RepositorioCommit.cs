using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.Repositorio.RepositorioBase
{
    public class RepositorioCommit : IRepositorioCommit
    {
        private DbContexto _db;

        public RepositorioCommit(DbContexto _db)
        {
            this._db = _db;
        }

        public bool Commit()
        {
            try { 
                return Convert.ToBoolean( this._db.SaveChanges() );
            }
            catch(Exception e)
            {
                throw new Exception(e.Message); 
            }
        }
    }
}
