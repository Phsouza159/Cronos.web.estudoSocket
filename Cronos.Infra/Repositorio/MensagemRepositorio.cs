using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Resources;
using Cronos.Infra.Contexto;
using Cronos.Infra.Repositorio.RepositorioBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using prmToolkit.NotificationPattern.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Cronos.Infra.Repositorio
{
    public class MensagemRepositorio : RepositorioBase<Mensagem, int>, IMensagemRepositorio
    {

        private IRepositorioCommit repositorioCommit { get; set; }

        public MensagemRepositorio(DbContexto _db , IRepositorioCommit repositorioCommit) : base(_db)
        {
            this.repositorioCommit = repositorioCommit;
        }

        public bool Commit()
        {
            return this.repositorioCommit.Commit();
        }


        public List<Mensagem> RecuperarMensagensUsuario(int idUsuario, params Expression<Func<Mensagem, object>>[] includeProperties)
        {
            List<Mensagem> resp = new List<Mensagem>();
            try
            {
                IQueryable<Mensagem> query = this.Include(_db.Mensagem, includeProperties);
                resp = query.Where(e => e.IdTo.Equals(idUsuario)).ToList();
            }
            catch (Exception e)
            {
                this.AddNotification("Erro MensagemRepositorio.RecuperarMensagensUsuario"
                            , ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
            }
            return resp;
        }

        public List<Mensagem> RecuperarMensagensNaoLidas(int idUsuario, params Expression<Func<Mensagem, object>>[] includeProperties)
        {
            List<Mensagem> resp = new List<Mensagem>();
            try
            {
                IQueryable<Mensagem> query = this.Include( _db.Mensagem , includeProperties);
                resp = query.Where(e => e.DataLida == null && e.IdTo.Equals(idUsuario)).ToList();
            }
            catch(Exception e)
            {
                this.AddNotification("Erro MensagemRepositorio.RecuperarMensagensNaoLidas"
                            , ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
            }
            return resp;
        }

        public bool GravarMensagensComoLidas(List<Mensagem> mensagens)
        {
            bool resp = false;
            try
            {
                mensagens.ForEach(e =>
                {
                    if (e.DataLida == null)
                        e.DataLida = DateTime.Now;
                });

                _db.Mensagem.UpdateRange(mensagens);
                resp = true;
            }
            catch(Exception e)
            {
                this.AddNotification("Erro MensagemRepositorio.GravarMensagensComoLidas"
                            , ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
            }
            return resp;
        }

    }
}
