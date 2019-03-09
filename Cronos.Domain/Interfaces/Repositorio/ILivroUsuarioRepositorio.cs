using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
using System.Collections.Generic;

namespace Cronos.Domain.Interfaces.Repositorio
{
    public interface ILivroUsuarioRepositorio : IRepositorioBase<LivroUsuario , int>
    {
        List<Livro> GetByUsuario(int IdUser);
    }
}
