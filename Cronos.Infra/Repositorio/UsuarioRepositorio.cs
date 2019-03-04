using Cronos.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using Cronos.Infra.Repositorio.RepositorioBase;
using Cronos.Domain.Entidades;
using Cronos.Infra.Contexto;
using Cronos.Domain.ObjectValues;

namespace Cronos.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContexto _db) : base(_db)
        {
        }

        public Usuario Login(string User, string Senha)
        {
            string Password = Senha.ConvertToMD5();

            if (_db.Usuario.Any(p => p.Nome.Equals(User) && p.Password.Equals(Password)))
                return _db.Usuario.Where(p => p.Nome.Equals(User) && p.Password.Equals(Password)).First();

            return null;
        }
    }
}
