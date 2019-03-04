using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Request
{
    public class LivroRequest
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Valor { get; set; }
        public string NumPaginas { get; set; }
    }
}
