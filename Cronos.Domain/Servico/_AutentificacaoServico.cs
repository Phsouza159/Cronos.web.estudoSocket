using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Map;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.ObjectValues;
using Cronos.Domain.Response;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Servico
{
    public class _AutentificacaoServico : Notifiable , IAutentificacaoServico
    {
        private IMapeamento _Mapper { get; set; }

        public _AutentificacaoServico(IUsuarioRepositorio usuarioDAO , IAutentificacaoRepositorio AutentificacaoDAO , IMapeamento _Mapper)
        {
            UsuarioDAO = usuarioDAO;
            this.AutentificacaoDAO = AutentificacaoDAO;
            this._Mapper = _Mapper;
        }

        private IUsuarioRepositorio UsuarioDAO { get; set; }
        private IAutentificacaoRepositorio AutentificacaoDAO { get; set; }

        public Usuario RecuperarPeloTokien(string tokien)
        {
            Usuario usuario = AutentificacaoDAO.GetTokien(tokien.ConvertToMD5());

            return usuario;
        }

        public UserResponse Login(string User, string Senha)
        {
            Usuario Usuario = UsuarioDAO.Login(User, Senha);
            if(Usuario != null)
            {
                UserResponse resp = _Mapper.MapUserResponse(Usuario);
                resp.Tokien = this.GerarTokien(Usuario);
                return resp;
            }
            return null;
        }

        public string ValidarTokien(string Tokien)
        {
            string TokienMD5 = Tokien.ConvertToMD5();

            bool IsAtivo = AutentificacaoDAO.ValidarTokien(Tokien);

            if(IsAtivo)
            {
                Usuario usuario = AutentificacaoDAO.GetTokien(TokienMD5);
                return this.GerarTokien(usuario);
            }

            return null;
        }

        public DateTime AutualizarDate()
        {
            int year = DateTime.Now.Year;
            int hour = DateTime.Now.Hour.Equals(23) ? 0 : DateTime.Now.Hour + 1;
            int dia = DateTime.Now.Hour.Equals(23) ? DateTime.Now.Day + 1 : DateTime.Now.Day;
            int Mes = DateTime.Now.Month;

            string date = $"{year}-{Mes}-{dia} {hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";

            return Convert.ToDateTime(date);
        }

        public string GerarTokien(int IdUser)
        {
            Usuario Usuario = UsuarioDAO.GetById(IdUser);

            string Tokien = Guid.NewGuid().ToString();

            if(Usuario.Autentificacao == null)
            {
                Usuario.Autentificacao = new Autentificacao();
                AutentificacaoDAO.Add(Usuario.Autentificacao);
            }

            Usuario.Autentificacao.Tokien = Tokien.ConvertToMD5();
            Usuario.Autentificacao.DataExpiracao = this.AutualizarDate();

            try { 
                AutentificacaoDAO.UpDate(Usuario.Autentificacao);
            }
            catch (Exception e)
            {
                this.AddNotification("Serviço", e.Message );
            }

            return Tokien;
        }

        public string GerarTokien(Usuario Usuario)
        {
            string Tokien = Guid.NewGuid().ToString();

            if (Usuario.Autentificacao == null)
            {
                Usuario.Autentificacao = new Autentificacao();
                AutentificacaoDAO.Add(Usuario.Autentificacao);
            }

            Usuario.Autentificacao.Tokien = Tokien.ConvertToMD5();
            Usuario.Autentificacao.DataExpiracao = this.AutualizarDate();

            AutentificacaoDAO.UpDate(Usuario.Autentificacao);

            return Tokien;
        }

        public bool LogOff(string Tokien)
        {
            Usuario usuario = this.RecuperarPeloTokien(Tokien);

            if (usuario.Equals(null) || usuario.Autentificacao.Equals(null))
                return false;

            usuario.Autentificacao.DataExpiracao = DateTime.Now;

            return this.AutentificacaoDAO.UpDate(usuario.Autentificacao);
        }
    }
}
