using Cronos.Domain.Entidades;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Interfaces.Map;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Request;
using Cronos.Domain.Response;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class LivroServico : Notifiable, ILivroServico
    {

        private ILivroUsuarioRepositorio LivroUsuarioDAO;
        private ILivroRepositorio LivroDAO;
        private IMapeamento Mapeamento;

        public LivroServico(ILivroRepositorio livroDAO, ILivroUsuarioRepositorio livroUsuarioDAO, IMapeamento Mapeamento)
        {
            this.LivroUsuarioDAO = livroUsuarioDAO;
            this.LivroDAO = livroDAO;
            this.Mapeamento = Mapeamento;
        }


        public void Add(Livro request)
        {
            this.AddNotifications(request);

            if (this.IsValid())
            {
                LivroDAO.Add(request);
                this.AddNotifications(LivroDAO.Notifications);
            }
        }

        public Livro Edit(Livro request)
        {
            Livro Livro = this.LivroDAO.GetById(request.Id);

            if (Livro != null)
            {
                Livro.Titulo = request.Titulo;
                Livro.Status = request.Status;
                Livro.Valor = request.Valor;
                Livro.Autor = request.Autor;
                Livro.NumPaginas = request.NumPaginas;

                this.AddNotifications(Livro.Valid().Notifications);

                if (this.IsValid())
                {
                    this.LivroDAO.UpDate(Livro);
                    this.AddNotifications(this.LivroDAO.Notifications);
                }
                else
                    this.AddNotification("Update Livro", "Não foi possível atualizar a entidade livro");
            }
            else
                this.AddNotification("Update Livro", "Não foi possível achar a entidade livro pelo ID: " + request.Id);

            return Livro;
        }

        public List<ListLivroResponse> GetByLivroUsuario(int IdUSer)
        {
            List<LivroUsuario> list = this.LivroUsuarioDAO.GetByUsuario(IdUSer);
            if (list.Count < 1)
                return null;

            List<ListLivroResponse> response = new List<ListLivroResponse>();

            list.ForEach(item =>
            {
                response.Add(Mapeamento.MapLivro(item.Livro));
            });

            return response;
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
