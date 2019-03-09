using Cronos.Domain.Entidades.Relacionamentos;
using System;

namespace Cronos.Domain.Interfaces.Entidades.Relacionamentos
{
    public interface ILivroUsuario
    {
        int Id { get; set; }
        int IdUsuario { get; set; }
        int IdLivro { get; set; }
        bool? Lido { get; set; }
        DateTime? Inicio { get; set; }
        DateTime? Fim { get; set; }
        bool Situacao { get; set; }
        DateTime DataInclusao { get; set; }

        LivroUsuario Valid();
    }
}
