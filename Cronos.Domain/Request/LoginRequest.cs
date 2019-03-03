using System.ComponentModel.DataAnnotations;

namespace Cronos.Domain.Request
{
    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Tokien { get; set; }
    }
}
