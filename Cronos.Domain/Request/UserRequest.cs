using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Request
{
    public class UserRequest
    {
        // user
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeUser { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public string SoudoBruto { get; set; }
        public string SoudoLiquido { get; set; }
        public DateTime DataPagemento { get; set; }
    }
}
