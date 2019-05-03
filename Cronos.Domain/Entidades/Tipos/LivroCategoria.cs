using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Entidades.Tipos
{
    public class LivroCategoria
    {
        public LivroCategoria()
        {

        }

        public virtual int Id { get; set; }
        public virtual string DescricaoCategoria { get; set; }

        public virtual List<Livro> Livro { get; set; }
    }
}
