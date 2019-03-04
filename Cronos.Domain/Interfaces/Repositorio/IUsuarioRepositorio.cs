using Cronos.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario , int>
    {
        Usuario Login(string User, string Senha);
    }
}
