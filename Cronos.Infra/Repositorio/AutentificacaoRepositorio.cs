using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cronos.Infra.Repositorio
{
    public class AutentificacaoRepositorio : RepositorioBase<Autentificacao, int> , IAutentificacaoRepositorio
    {
        public AutentificacaoRepositorio(DbContexto _db) : base(_db)
        {
        }

        public Usuario GetTokien(string Tokien)
        {
            if(_db.Autentificacao.Any(e => e.Tokien.Equals(Tokien) && ( e.DataExpiracao > DateTime.Now)))
            { 
               return _db.Autentificacao
                           .Include( e => e.Usuario)
                           .Where(p => p.Tokien.Equals(Tokien)).First().Usuario;
            }

            return null;
        }

        public bool ValidarTokien(string Tokien)
        {
            return _db.Autentificacao.Any(e => e.Tokien.Equals(Tokien) && (e.DataExpiracao < DateTime.Now));
        }
    }
}
