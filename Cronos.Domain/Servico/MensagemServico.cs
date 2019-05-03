using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class MensagemServico : Notifiable , IMensagemServico
    {
        public IMensagemRepositorio mensagemRepositorio { get; set; }

        public MensagemServico(IMensagemRepositorio mensagemRepositorio)
        {
            this.mensagemRepositorio = mensagemRepositorio;
            this.mensagemRepositorio.IncludeAux( e => e.UsuarioTo);
        }

        public bool Send(Mensagem mensagem, bool Commit = false)
        {
            bool resp = false;
            try
            {
                resp = this.mensagemRepositorio.Add(mensagem);

                if (Commit)
                {
                    this.mensagemRepositorio.Commit();
                }

                this.AddNotifications(this.mensagemRepositorio.Notifications);
            }
            catch(Exception e)
            {
                this.AddNotification("Erro MensagemServico.Send", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
            }
            return resp;
        }

        public List<Mensagem> RecuperarMensagensUsuario(Usuario usuario)
        {
            List<Mensagem> resp = new List<Mensagem>();
            try
            {
                resp = this.mensagemRepositorio.RecuperarMensagensUsuario(usuario.Id, this.mensagemRepositorio.includeProperties); ;
                this.AddNotifications(this.mensagemRepositorio.Notifications);
            }
            catch (Exception e)
            {
                this.AddNotification("Erro MensagemServico.RecuperarMensagensUsuario", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
            }
            return resp;
        }

        public List<Mensagem> RecuperarMensagemUsuarioNaoLidas(Usuario usuario)
        {
            List<Mensagem> resp = new List<Mensagem>();
            try
            {
                resp = this.mensagemRepositorio.RecuperarMensagensNaoLidas(usuario.Id , this.mensagemRepositorio.includeProperties); ;
                this.AddNotifications(this.mensagemRepositorio.Notifications);
            }
            catch (Exception e)
            {
                this.AddNotification("Erro MensagemServico.RecuperarMensagemUsuarioNaoLidas", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
            }
            return resp;
        }

        public bool GravarMensagemComoLida(List<Mensagem> mensagens , bool commit)
        {
            bool resp = false;
            try
            {
                if (mensagens.Count < 1)
                    return false;

                resp = this.mensagemRepositorio.GravarMensagensComoLidas(mensagens);
                if (resp)
                {
                    resp = this.mensagemRepositorio.Commit();
                }
                this.AddNotifications(this.mensagemRepositorio.Notifications);
            }
            catch(Exception e)
            {
                this.AddNotification("Erro MensagemServico.GravarMensagemComoLida", ResourceNotifiable.ExceptionMensagem.ToFormat(e.Message));
            }
            return resp;
        }
    }
}
