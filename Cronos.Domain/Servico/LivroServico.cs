using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Request;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class LivroServico : Notifiable , ILivroServico
    {
        public LivroServico(ILivroRepositorio livroDAO)
        {
            LivroDAO = livroDAO;
        }

        private ILivroRepositorio LivroDAO { get; set; }

        public void Add(Livro request)
        {
            this.AddNotifications(request);

            if(this.IsValid())
            {
                LivroDAO.Add(request);
                this.AddNotifications(LivroDAO.Notifications);
            }
        }
    }
}
