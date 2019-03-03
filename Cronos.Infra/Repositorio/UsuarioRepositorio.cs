using Cronos.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using Cronos.Infra.Repositorio.RepositorioBase;
using Cronos.Domain.Entidades;
using Cronos.Infra.Contexto;

namespace Cronos.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContexto _db) : base(_db)
        {
        }
    }
}
