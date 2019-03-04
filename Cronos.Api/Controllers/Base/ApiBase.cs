
using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Repositorio;
using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Api.Controllers.Base
{
    public class ApiBase: ControllerBase
    {
        protected Usuario UserLogado { get; set; }
        private IAutentificacaoServico AutentificacaoServico { get; set; }
        private IRepositorioCommit DbService { get; set; }

        protected ApiBase(IRepositorioCommit DbService , IAutentificacaoServico AutentificacaoServico)
        {
            this.DbService = DbService;
            this.AutentificacaoServico = AutentificacaoServico;
        }

        protected string ValidarAcesso(string token)
        {
            return null;
        }

        protected string ValidarAcesso(string user , string senha)
        {
            string tokien = AutentificacaoServico.Login(user ,senha);

            var nullablal = this.Commit(new object() , AutentificacaoServico);

            return tokien;
        }


        protected CommitRespose Commit(object obj ,params INotifiable[] notifications)
        {
            CommitRespose respose = new CommitRespose();
            respose.Notificaceos = new List<string>();

            foreach (var notifiables in notifications)
                    foreach (var notification in notifiables.Notifications)
                        respose.Notificaceos.Add($"Propriedade: {notification.Property}. Messagem: {notification.Message}");

            if(respose.Notificaceos.Count > 0)
            {
                respose.Salve = false;
                return respose;
            }

            if(!DbService.Commit())
            {
                respose.Salve = false;
                respose.Notificaceos.Add("Erro: não foi possível salvar operção");
                return respose;
            }

            respose.Salve = true;
            respose.Response = obj;
            respose.Tokien = "";
            return respose;
        }
    }
}
