﻿using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cronos.Infra.Repositorio
{
    public class LivroUsuarioRepositorio : RepositorioBase<LivroUsuario, int>, ILivroUsuarioRepositorio
    {
        public LivroUsuarioRepositorio(DbContexto _db) : base(_db)
        {
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
