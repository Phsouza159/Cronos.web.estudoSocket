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

        public int Id { get; set; }
        public string DescricaoCategoria { get; set; }

        public virtual List<Livro> Livro { get; set; }
    }
}
