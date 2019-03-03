using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Entidades
{
    public interface IAutentificacao
    {
        int Id { get; set; }
        string Tokien { get; set; }
        DateTime DataExpiracao { get; set; }
    }
}
