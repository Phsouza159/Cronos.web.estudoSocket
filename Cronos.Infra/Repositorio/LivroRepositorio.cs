using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.Repositorio
{
    public class LivroRepositorio : RepositorioBase<Livro, int>, ILivroRepositorio
    {
        public LivroRepositorio(DbContexto _db) : base(_db)
        {
        }
    }
}
