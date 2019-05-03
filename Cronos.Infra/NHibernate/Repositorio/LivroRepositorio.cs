using System.Linq;
using Cronos.Domain.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace Cronos.Infra.NHibernate.Repositorio
{
    public class LivroRepositorio : BaseRepositorio<Livro> , Domain.Interfaces.NHibernite.ILivroRepositorio
    {
        public LivroRepositorio()
        {
        }

        public override List<Livro> GetAll(params Expression<Func<Livro, object>>[] includeProperties)
        {
            using (ISession session = DbContexto.AbrirSession())
            {
                try
                {
                    var r = session.Query<Livro>()
                            .Fetch(e => e.LivroCategoria);

                    return r.ToList();

                    //return (from e in session.Query<Livro>()
                    //        .Fetch(e => e.LivroCategoria)
                    //        select e).ToList();
                }
                catch (Exception e)
                {
                    this.AddNotification("Listar entidade base", e.Message);
                    return new List<Livro>();
                }
            }
        }
    }
}
