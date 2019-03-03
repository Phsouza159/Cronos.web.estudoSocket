using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.Repositorio
{
    public class LivroUsuarioRepositorio : RepositorioBase<LivroUsuario, int>, ILivroUsuarioRepositorio
    {
        public LivroUsuarioRepositorio(DbContexto _db) : base(_db)
        {
        }
    }
}
