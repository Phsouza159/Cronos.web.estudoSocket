using Cronos.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using Cronos.Infra.Repositorio.RepositorioBase;
using Cronos.Domain.Entidades;
using Cronos.Infra.Contexto;
using Cronos.Domain.ObjectValues;
using Microsoft.EntityFrameworkCore;

namespace Cronos.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContexto _db) : base(_db)
        {
        }

        public Usuario GetById(int Id)
        {
            return _db.Usuario
                    .Include(e => e.Autentificacao)
                    .Where(e => e.Id.Equals(Id))
                    .First();
        }

        public Usuario Login(string User, string Senha)
        {
            string Password = Senha.ConvertToMD5();

            if (_db.Usuario.Any(p => p.User.Equals(User) && p.Password.Equals(Password)))
                return _db.Usuario.Include(e => e.Autentificacao).Where(p => p.User.Equals(User) && p.Password.Equals(Password)).First();

            return null;
        }
    }
}
