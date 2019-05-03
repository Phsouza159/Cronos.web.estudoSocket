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

        public virtual int IdUsuario{ get; set; }
        public virtual int IdLivro { get; set; }
        public virtual bool? Lido { get; set; }
        public virtual DateTime? Inicio { get; set; }
        public virtual DateTime? Fim { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Livro Livro { get; set; }

        public virtual LivroUsuario Valid()
        {

            return this;
        }
    }
}
