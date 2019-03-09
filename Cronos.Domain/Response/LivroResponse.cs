using Cronos.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Response
{
    public class LivroResponse
    {
        public string Tokien { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
