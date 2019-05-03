using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.NHibernite;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.Repositorio
{
    public class LivroRepositorio : RepositorioBase<Livro, int>, Domain.Interfaces.Repositorio.ILivroRepositorio
    {
        public Domain.Interfaces.NHibernite.ILivroRepositorio _Hibernite { get; set; }

        public LivroRepositorio(DbContexto _db
            , Domain.Interfaces.NHibernite.ILivroRepositorio _Hibernite)
            : base(_db)
        {
            this._Hibernite = _Hibernite;
        }

       
    }
}
