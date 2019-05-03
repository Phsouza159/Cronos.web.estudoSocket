using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface ILivroUsuarioRepositorio : INotifiable, IRepositorioBase<LivroUsuario , int>
    {
        List<LivroUsuario> GetByUsuario(int IdUser);
        List<LivroUsuario> GetByUsuario(int id, params Expression<Func<LivroUsuario, object>>[] includeProperties);
    }
}
