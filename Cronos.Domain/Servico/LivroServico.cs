using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
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

        private ILivroUsuarioRepositorio LivroUsuarioDAO;
        private ILivroRepositorio LivroDAO;

        public LivroServico(ILivroRepositorio livroDAO , ILivroUsuarioRepositorio livroUsuarioDAO )
        {
            this.LivroUsuarioDAO = livroUsuarioDAO;
            this.LivroDAO = livroDAO;
        }


        public void Add(Livro request)
        {
            this.AddNotifications(request);

            if(this.IsValid())
            {
                LivroDAO.Add(request);
                this.AddNotifications(LivroDAO.Notifications);
            }
        }

        public List<Livro> GetByLivroUsuario(int IdUSer)
        {
            return this.LivroUsuarioDAO.GetByUsuario(IdUSer);
        }

        public void Vincular(int IdLivro, int IdUser)
        {
            LivroUsuario livroUsuario = new LivroUsuario()
            {
                IdLivro = IdLivro,
                IdUsuario = IdUser,
                DataInclusao = DateTime.Now,
                Situacao = true
            };

            this.AddNotifications(livroUsuario.Valid());

            if (this.IsValid())
            {
                this.LivroUsuarioDAO.Add(livroUsuario);
            }
            else
            {
                this.AddNotifications(this.LivroUsuarioDAO.Notifications);
            }
        }
    }
}
