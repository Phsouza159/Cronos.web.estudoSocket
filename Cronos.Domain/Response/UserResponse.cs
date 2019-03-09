using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Response
{
    public class UserResponse
    {
        public string Nome{ get; set; }
        public string Sobrenome { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Tokien { get; set; }
    }
}
