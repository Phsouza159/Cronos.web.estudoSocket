using Cronos.Domain.Interfaces.Servico;
using Cronos.Domain.Servico;
using Cronos.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebSockets.ws.Interfaces;
using Cronos.Infra.Fabrica;
using Cronos.Infra.Contexto;

namespace WebSockets.ws.Servico
{
    public class _WebSocketServico : IWebSocketServico
    {
        public DbContexto _db { get; set; }
        public IMensagemServico mensagemServico {get;set;}
        public IAutentificacaoServico autentificacaoServico { get; set; }
        public ILivroServico livroServico { get; set; }

        public _WebSocketServico(DbContexto _db)
        {
            Repositorio repositorio = new Repositorio(_db);

            this._db = _db;
            this.livroServico = repositorio.getLivroServico();
            this.autentificacaoServico = repositorio.getAutentificacaoServico();
            this.mensagemServico = repositorio.getMensagemServico();
        }

    }
}
