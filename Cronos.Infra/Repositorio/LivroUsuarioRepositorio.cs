using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cronos.Infra.Repositorio
{
    public class LivroUsuarioRepositorio : RepositorioBase<LivroUsuario, int>, ILivroUsuarioRepositorio
    {
        public LivroUsuarioRepositorio(DbContexto _db) : base(_db)
        {
        }

        public List<LivroUsuario> GetByUsuario(int id, params Expression<Func<LivroUsuario, object>>[] includeProperties)
        {

            if (includeProperties.Any())
            {
                IQueryable queryable = this.Include(_db.Set<LivroUsuario>(), includeProperties);
                return queryable.OfType<LivroUsuario>().ToList();
            }


            return _db.Set<LivroUsuario>().Where(x => x.IdUsuario.Equals(id)).ToList();

          //  return queryable.OfType<LivroUsuario>().ToList();
        }

        public List<LivroUsuario> GetByUsuario(int IdUser)
        {
            return _db.LivroUsuario
                        .Include(e => e.Livro)
                        .Include(e => e.Livro.LivroCategoria)
                        .Where(e => e.IdUsuario.Equals(IdUser))
                        .ToList();
        }
    }
}
