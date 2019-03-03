using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class UsuarioServico : IUsuarioServico
    {
        public UsuarioServico(IUsuarioRepositorio UsuarioDAO)
        {
            _UsuarioDAO = UsuarioDAO;
        }

        public IUsuarioRepositorio _UsuarioDAO { get; set; }


        public void AddUser(Usuario usuario)
        {
            _UsuarioDAO.Add(usuario);
        }
    }
}
