using Cronos.Domain.Config;
using Cronos.Domain.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Text;
using Cronos.Domain.Config;

namespace Cronos.Domain.Servico
{
    public class _ConfiguracaoServico : IConfiguracaoServico
    {
        private dynamic _Config { get; set; }

        public _ConfiguracaoServico()
        {
            this._Config = Config.Config.Get();
        }

        public NautilosConig RecuperarNautilosConfig()
        {
            throw new NotImplementedException();
        }
    }
}
