using Cronos.Domain.Entidades.Base;
using Cronos.Domain.Interfaces.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Entidades
{
    public class Salario : EntidadeBase, ISalario
    {

        public Salario()
        {

        }

        public Salario(double soudoBruto, double soudoLiquido, DateTime dataPagemento)
        {
            SoudoBruto = soudoBruto;
            SoudoLiquido = soudoLiquido;
            DataPagemento = dataPagemento;
        }

        public double SoudoBruto { get; set; }
        public double SoudoLiquido { get; set; }
        public DateTime DataPagemento { get; set; }

        public Salario Valid()
        {
            return this;
        }

        public virtual Usuario Usuario { get; set; }

    }
}
