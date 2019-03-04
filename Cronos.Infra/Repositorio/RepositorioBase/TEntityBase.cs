using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.Repositorio.RepositorioBase
{
    public class TEntityBase<Id>
    {
        public Id id { get; set; }
        public bool Situacao { get; set; }
    }
}
