using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class UsuarioServico : Notifiable , IUsuarioServico
    {
        public UsuarioServico(IUsuarioRepositorio UsuarioDAO)
        {
            _UsuarioDAO = UsuarioDAO;
        }

        public IUsuarioRepositorio _UsuarioDAO { get; set; }


        public void AddUser(Usuario usuario)
        {
            try
            {
                _UsuarioDAO.Add(usuario);
                this.AddNotifications(usuario);
            }
            catch(Exception e)
            {
                this.AddNotification("Exception usuario" , "Erro ao tentar salvar adicionar usuario: " + e.Message);
            }
        }
    }
}
