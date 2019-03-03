using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.Repositorio
{
    public class SalarioRepositorio : RepositorioBase<Salario, int>, ISalarioRepositorio
    {
        public SalarioRepositorio(DbContexto _db) : base(_db)
        {
        }
    }
}
