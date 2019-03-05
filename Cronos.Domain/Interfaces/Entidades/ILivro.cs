using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Entidades
{
    public interface ILivro : IBase<Livro>
    {
        string Titulo { get; set; }
        string Autor { get; set; }
        double? Valor { get; set; }
        int? NumPaginas { get; set; }
        short? Status { get; set; }
    }
}
