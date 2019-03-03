using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Entidades.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Entidades
{
    public interface IUsuario : IBase<Usuario>
    {
        int? IdSalario { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}
