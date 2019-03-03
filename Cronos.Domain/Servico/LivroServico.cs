using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class LivroServico : ILivroServico
    {
        public LivroServico(ILivroRepositorio livroDAO)
        {
            LivroDAO = livroDAO;
        }

        private ILivroRepositorio LivroDAO { get; set; }
    }
}
