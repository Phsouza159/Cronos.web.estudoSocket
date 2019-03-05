using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Entidades.Relacionamentos;
using System;

namespace Cronos.Domain.Entidades.Relacionamentos
{
    public class LivroUsuario : EntidadeBase , ILivroUsuario
    {
        public LivroUsuario()
        {

        }

        public int IdUsuario{ get; set; }
        public int IdLivro{ get; set; }
        public bool? Lido { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Livro Livro { get; set; }
    }
}
