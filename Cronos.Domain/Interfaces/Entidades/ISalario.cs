using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Interfaces.Entidades
{
    public interface ISalario : IBase<Salario>
    {
        double SoudoBruto { get; set; }
        double SoudoLiquido { get; set; }
        DateTime DataPagemento { get; set; }
        
    }
}
