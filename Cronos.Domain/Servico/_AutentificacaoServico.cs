using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class _AutentificacaoServico : IAutentificacaoServico
    {
        public _AutentificacaoServico(IUsuarioRepositorio usuarioDAO)
        {
            UsuarioDAO = usuarioDAO;
        }

        private IUsuarioRepositorio UsuarioDAO { get; set; }
    }
}
