using Cronos.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Cronos.Infra.Repositorio;
using Cronos.Domain.Servico;
using Cronos.Domain.Entidades.Relacionamentos;
using Cronos.Domain.Mapper;
using Cronos.Infra.Repositorio.RepositorioBase;

namespace Cronos.Infra.Fabrica
{
    public class Repositorio
    {

        public DbContexto _db { get; set; }

        public Repositorio(DbContexto _db)
        {
            this._db = _db;
        }

        // Servicos //
        public LivroServico getLivroServico()
        {
            return new LivroServico(getLivroRepositorio(), getLivroUsuarioRepositorio(), getMapeamento());
        }

        public _AutentificacaoServico getAutentificacaoServico()
        {
            return new _AutentificacaoServico(getUsuarioRepositorio() , getAutentificacaoRepositorio() , getMapeamento());
        }

        public MensagemServico getMensagemServico()
        {
            return new MensagemServico( getMensagemRepositorio() );
        }

        // Repositorio //
        public RepositorioCommit getRepositorioCommit()
        {
            return new RepositorioCommit(_db);
        }


        public LivroRepositorio getLivroRepositorio()
        {
            return new LivroRepositorio(_db , null);
        }

        public LivroUsuarioRepositorio getLivroUsuarioRepositorio()
        {
            return new LivroUsuarioRepositorio(_db);
        }

        public UsuarioRepositorio getUsuarioRepositorio()
        {
            return new UsuarioRepositorio(_db);
        }

        public Mapeamento getMapeamento()
        {
            return new Mapeamento();
        }

        public AutentificacaoRepositorio getAutentificacaoRepositorio()
        {
            return new AutentificacaoRepositorio(_db);
        }

        public MensagemRepositorio getMensagemRepositorio()
        {
            return new MensagemRepositorio(_db , getRepositorioCommit());
        }
    }
}
